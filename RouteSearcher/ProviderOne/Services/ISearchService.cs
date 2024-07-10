using ProviderOneContracts.Contracts;

namespace ProviderOne.Services;

public interface ISearchService
{
    Task<ProviderOneSearchResponse> SearchAsync(
        ProviderOneSearchRequest request,
        CancellationToken cancellationToken);
    Task<bool> IsAvailableAsync(CancellationToken cancellationToken);
}
