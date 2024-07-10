using Microsoft.Extensions.Caching.Memory;
using ProviderOneContracts.Contracts;
using ProviderTwoContracts.Contracts;
using RouteSearcher.Configuration;
using RouteSearcher.Contracts;
using Route = RouteSearcher.Contracts.Route;

namespace RouteSearcher.Services;

public class SearchService : ISearchService
{
    private static readonly HttpClient _client = new();
    private readonly IMemoryCache _memoryCache;
    private readonly ProviderConfig _providerConfig;

    public SearchService(
        IMemoryCache memoryCache,
        ProviderConfig providerConfig)
    {
        _memoryCache = memoryCache;
        _providerConfig = providerConfig;
    }

    public Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }

    public async Task<SearchResponse> SearchAsync(
        SearchRequest request,
        CancellationToken cancellationToken)
    {
        var result = new SearchResponse
        {
            Routes = [],
            MinPrice = 0,
            MaxPrice = 0,
            MinMinutesRoute = 0,
            MaxMinutesRoute = 0
        };

        if (request.Filters != null && request.Filters.OnlyCached != null && request.Filters.OnlyCached == true)
        {
            _memoryCache.TryGetValue<SearchResponse>(request, out var response);
            if(response != null)
            {
                result = response;
            }
        }
        else
        {
            var response = await _memoryCache.GetOrCreateAsync(request, async entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                entry.Priority = CacheItemPriority.High;
                return await GetAggregatedSearchResult(request);
            });

            if(response != null)
            {
                result = response;
            }
        }

        return result;
    }

    private async Task<SearchResponse> GetAggregatedSearchResult(SearchRequest request)
    {
        var routes = await GetRoutesFromAllProviders(request);
        var result = new SearchResponse
        {
            MinPrice = 0,
            MaxPrice = 0,
            MinMinutesRoute = 0,
            MaxMinutesRoute = 0,
            Routes = []
        };

        if(routes.Count == 0)
        {
            return result;
        }

        result.MinPrice = routes.Min(r => r.Price);
        result.MaxPrice = routes.Max(r => r.Price);
        result.MinMinutesRoute = routes.Min(r => r.DestinationDateTime.Subtract(r.OriginDateTime).Minutes);
        result.MaxMinutesRoute = routes.Max(r => r.DestinationDateTime.Subtract(r.OriginDateTime).Minutes);
        result.Routes = routes.ToArray();

        return result;
    }

    private async Task<List<Route>> GetRoutesFromAllProviders(SearchRequest request)
    {
        var result = new List<Route>();
        result.AddRange(await GetRoutesFromProviderOne(request));
        result.AddRange(await GetRoutesFromProviderTwo(request));

        return result;
    }

    private async Task<List<Route>> GetRoutesFromProviderOne(SearchRequest request)
    {
        var result = new List<Route>();

        using var pingResponse = await _client.GetAsync($"{_providerConfig.ProviderOneApiUrl}/ping");
        if(pingResponse.StatusCode != System.Net.HttpStatusCode.OK)
        {
            return result;
        }

        using var responseMessage = await _client.PostAsJsonAsync($"{_providerConfig.ProviderOneApiUrl}/search", new ProviderOneSearchRequest
        {
            From = request.Origin,
            To = request.Destination,
            DateFrom = request.OriginDateTime,
            DateTo = request.Filters?.DestinationDateTime,
            MaxPrice = request.Filters?.MaxPrice
        });

        var providerOneResponse = await responseMessage.Content.ReadFromJsonAsync<ProviderOneSearchResponse>();
        if(providerOneResponse != null)
        {
            result.AddRange(providerOneResponse.Routes.Select(r => new Route
            {
                Id = Guid.NewGuid(),
                Price = r.Price,
                TimeLimit = r.TimeLimit,
                OriginDateTime = r.DateFrom,
                DestinationDateTime = r.DateTo,
                Origin = r.From,
                Destination = r.To
            }));
        }

        return result;
    }

    private async Task<List<Route>> GetRoutesFromProviderTwo(SearchRequest request)
    {
        var result = new List<Route>();

        using var pingResponse = await _client.GetAsync($"{_providerConfig.ProviderTwoApiUrl}/ping");
        if (pingResponse.StatusCode != System.Net.HttpStatusCode.OK)
        {
            return result;
        }

        using var responseMessage = await _client.PostAsJsonAsync($"{_providerConfig.ProviderTwoApiUrl}/search", new ProviderTwoSearchRequest
        {
            Departure = request.Origin,
            Arrival = request.Destination,
            DepartureDate = request.OriginDateTime,
            ArrivalDate = request.Filters?.DestinationDateTime,
            MinTimeLimit = request.Filters?.MinTimeLimit
        });

        var providerTwoResponse = await responseMessage.Content.ReadFromJsonAsync<ProviderTwoSearchResponse>();
        if(providerTwoResponse != null)
        {
            result.AddRange(providerTwoResponse.Routes.Select(r => new Route
            {
                Id = Guid.NewGuid(),
                Price = r.Price,
                TimeLimit = r.TimeLimit,
                OriginDateTime = r.Departure.Date,
                DestinationDateTime = r.Arrival.Date,
                Origin = r.Departure.Point,
                Destination = r.Arrival.Point
            }));
        }

        return result;
    }
}
