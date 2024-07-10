using Common.Converters;
using System.Text.Json.Serialization;

namespace ProviderOneContracts.Contracts;

public class ProviderOneRoute
{
    // Mandatory
    // Start point of route
    public string From { get; set; }

    // Mandatory
    // End point of route
    public string To { get; set; }

    // Mandatory
    // Start date of route
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime DateFrom { get; set; }

    // Mandatory
    // End date of route
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime DateTo { get; set; }

    // Mandatory
    // Price of route
    public decimal Price { get; set; }

    // Mandatory
    // Timelimit. After it expires, route became not actual
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime TimeLimit { get; set; }
}