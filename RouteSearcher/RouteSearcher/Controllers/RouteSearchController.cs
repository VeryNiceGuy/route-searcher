using Microsoft.AspNetCore.Mvc;
using RouteSearcher.Contracts;
using RouteSearcher.Services;

namespace RouteSearcher.Controllers;

[ApiController]
[Route("api/[controller]")]
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

    [HttpGet("IsAvailable")]
    public async Task<IActionResult> IsAvailable()
    {
        var result =  await _searchService.IsAvailableAsync(new CancellationToken());
        if(result)
        {
            return Ok();
        }
        else
        {
            return StatusCode(500);
        }
    }

    [HttpPost("Search")]
    public async Task<SearchResponse> Search(SearchRequest request)
    {
        return await _searchService.SearchAsync(request, new CancellationToken());
    }
}
