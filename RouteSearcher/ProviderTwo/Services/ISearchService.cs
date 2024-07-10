using ProviderTwoContracts.Contracts;

namespace ProviderTwo.Services;

public interface ISearchService
{
    Task<ProviderTwoSearchResponse> SearchAsync(ProviderTwoSearchRequest request, CancellationToken cancellationToken);
    Task<bool> IsAvailableAsync(CancellationToken cancellationToken);
}
