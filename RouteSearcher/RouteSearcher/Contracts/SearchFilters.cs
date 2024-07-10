using Common.Converters;
using System.Text.Json.Serialization;

namespace RouteSearcher.Contracts;

public class SearchFilters
{
    // Optional
    // End date of route
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime? DestinationDateTime { get; set; }

    // Optional
    // Maximum price of route
    public decimal? MaxPrice { get; set; }

    // Optional
    // Minimum value of timelimit for route
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime? MinTimeLimit { get; set; }

    // Optional
    // Forcibly search in cached data
    public bool? OnlyCached { get; set; }
}
