using ProviderTwoContracts.Contracts;

namespace ProviderTwo.Services;

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

    public Task<ProviderTwoSearchResponse> SearchAsync(
        ProviderTwoSearchRequest request,
        CancellationToken cancellationToken)
    {
        var routes = Array.Empty<ProviderTwoRoute>();

        if (request.MinTimeLimit == null && request.ArrivalDate == null)
        {
            routes = _dbContext.Routes.Where(
                r => r.DeparturePoint == request.Departure
                && r.ArrivalPoint == request.Arrival
                && r.DepartureDate == request.DepartureDate)
                .Select(r => ToProviderTwoRoute(r)).ToArray();
        }
        else if(request.MinTimeLimit != null && request.ArrivalDate == null)
        {
            routes = _dbContext.Routes.Where(
                r => r.DeparturePoint == request.Departure
                && r.ArrivalPoint == request.Arrival
                && r.DepartureDate == request.DepartureDate
                && r.TimeLimit >= request.MinTimeLimit)
                .Select(r => ToProviderTwoRoute(r)).ToArray();
        }
        else if (request.MinTimeLimit == null && request.ArrivalDate != null)
        {
            routes = _dbContext.Routes.Where(
                r => r.DeparturePoint == request.Departure
                && r.ArrivalPoint == request.Arrival
                && r.DepartureDate == request.DepartureDate
                && r.ArrivalDate == request.ArrivalDate)
                .Select(r => ToProviderTwoRoute(r)).ToArray();
        }
        else if(request.MinTimeLimit != null && request.ArrivalDate != null)
        {
            routes = _dbContext.Routes.Where(
                r => r.DeparturePoint == request.Departure
                && r.ArrivalPoint == request.Arrival
                && r.DepartureDate == request.DepartureDate
                && r.ArrivalDate == request.ArrivalDate
                && r.TimeLimit >= request.MinTimeLimit)
                .Select(r => ToProviderTwoRoute(r)).ToArray();
        }

        return Task.FromResult(new ProviderTwoSearchResponse
        {
            Routes = routes
        });
    }

    private static ProviderTwoRoute ToProviderTwoRoute(Models.Route r)
        => new ProviderTwoRoute
    {
        Departure = new ProviderTwoPoint { Point = r.DeparturePoint, Date = r.DepartureDate },
        Arrival = new ProviderTwoPoint { Point = r.ArrivalPoint, Date = r.ArrivalDate },
        Price = r.Price,
        TimeLimit = r.TimeLimit
    };
}
