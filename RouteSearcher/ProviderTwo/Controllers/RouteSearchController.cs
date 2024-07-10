using Microsoft.AspNetCore.Mvc;
using ProviderTwo.Services;
using ProviderTwoContracts.Contracts;

namespace ProviderTwo.Controllers;

[ApiController]
[Route("api/v1")]
public class RouteSearchController : ControllerBase
{
    private readonly ILogger<RouteSearchController> _logger;
    private readonly ISearchService _searchService;

    public RouteSearchController(
        ILogger<RouteSearchController> logger,
        ISearchService searchService)
    {
        _logger = logger;
        _searchService = searchService;
    }

    [HttpGet("Ping")]
    public async Task<IActionResult> IsAvailable()
    {
        var result = await _searchService.IsAvailableAsync(new CancellationToken());
        if (result)
        {
            return Ok();
        }
        else
        {
            return StatusCode(500);
        }
    }

    [HttpPost("Search")]
    public async Task<ProviderTwoSearchResponse> Search(ProviderTwoSearchRequest request)
    {
        return await _searchService.SearchAsync(request, new CancellationToken());
    }
}
