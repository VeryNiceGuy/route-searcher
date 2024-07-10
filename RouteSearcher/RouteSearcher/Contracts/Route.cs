using Common.Converters;
using System.Text.Json.Serialization;

namespace RouteSearcher.Contracts;

public class Route
{
    // Mandatory
    // Identifier of the whole route
    public Guid Id { get; set; }

    // Mandatory
    // Start point of route
    public string Origin { get; set; }

    // Mandatory
    // End point of route
    public string Destination { get; set; }

    // Mandatory
    // Start date of route
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime OriginDateTime { get; set; }

    // Mandatory
    // End date of route
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime DestinationDateTime { get; set; }

    // Mandatory
    // Price of route
    public decimal Price { get; set; }

    // Mandatory
    // Timelimit. After it expires, route became not actual
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime TimeLimit { get; set; }
}