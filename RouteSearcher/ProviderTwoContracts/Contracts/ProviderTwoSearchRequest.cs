using Common.Converters;
using System.Text.Json.Serialization;

namespace ProviderTwoContracts.Contracts;

// HTTP POST http://provider-two/api/v1/search
public class ProviderTwoSearchRequest
{
    // Mandatory
    // Start point of route, e.g. Moscow 
    public string Departure { get; set; }

    // Mandatory
    // End point of route, e.g. Sochi
    public string Arrival { get; set; }

    // Mandatory
    // Start date of route
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime DepartureDate { get; set; }

    // Mandatory
    // End date of route
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime? ArrivalDate { get; set; }

    // Optional
    // Minimum value of timelimit for route
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime? MinTimeLimit { get; set; }
}
