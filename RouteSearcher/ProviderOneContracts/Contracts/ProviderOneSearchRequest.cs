using Common.Converters;
using System.Text.Json.Serialization;

namespace ProviderOneContracts.Contracts;

// HTTP POST http://provider-one/api/v1/search

public class ProviderOneSearchRequest
{
    // Mandatory
    // Start point of route, e.g. Moscow 
    public string From { get; set; }

    // Mandatory
    // End point of route, e.g. Sochi
    public string To { get; set; }

    // Mandatory
    // Start date of route
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime DateFrom { get; set; }

    // Optional
    // End date of route
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime? DateTo { get; set; }

    // Optional
    // Maximum price of route
    public decimal? MaxPrice { get; set; }
}
