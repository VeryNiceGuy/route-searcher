using ProviderOneContracts.Contracts;

namespace ProviderOne.Services;

public class SearchService : ISearchService
{
    private readonly Models.RouteSearchContext _dbContext;

    public SearchService(Models.RouteSearchContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }

    public Task<ProviderOneSearchResponse> SearchAsync(
        ProviderOneSearchRequest request,
        CancellationToken cancellationToken)
    {
        var routes = Array.Empty<ProviderOneRoute>();

        if (request.DateTo == null && request.MaxPrice == null)
        {
            routes = _dbContext.Routes.Where(
                r => r.From == request.From
                && r.To == request.To
                && r.DateFrom == request.DateFrom)
                .Select(r => ToProviderOneRoute(r)).ToArray();
        }
        else if (request.DateTo != null && request.MaxPrice == null)
        {
            routes = _dbContext.Routes.Where(
                r => r.From == request.From
                && r.To == request.To
                && r.DateFrom == request.DateFrom
                && r.DateTo == request.DateTo.Value)
                .Select(r => ToProviderOneRoute(r)).ToArray();
        }
        else if (request.DateTo == null && request.MaxPrice != null)
        {
            routes = _dbContext.Routes.Where(
                r => r.From == request.From
                && r.To == request.To
                && r.DateFrom == request.DateFrom
                && r.Price <= request.MaxPrice.Value)
                .Select(r => ToProviderOneRoute(r)).ToArray();
        }
        else if (request.DateTo != null && request.MaxPrice != null)
        {
            routes = _dbContext.Routes.Where(
                r => r.From == request.From
                && r.To == request.To
                && r.DateFrom == request.DateFrom
                && r.DateTo == request.DateTo.Value
                && r.Price <= request.MaxPrice.Value)
                .Select(r => ToProviderOneRoute(r)).ToArray();
        }

        return Task.FromResult(new ProviderOneSearchResponse
        {
            Routes = routes
        });
    }

    private static ProviderOneRoute ToProviderOneRoute(Models.Route r)
        => new ProviderOneRoute
    {
        From = r.From,
        To = r.To,
        DateFrom = r.DateFrom,
        DateTo = r.DateTo,
        Price = r.Price,
        TimeLimit = r.TimeLimit
    };
}
