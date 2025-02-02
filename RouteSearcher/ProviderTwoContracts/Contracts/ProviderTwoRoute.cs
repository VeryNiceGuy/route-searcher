﻿using Common.Converters;
using System.Text.Json.Serialization;

namespace ProviderTwoContracts.Contracts;

public class ProviderTwoRoute
{
    // Mandatory
    // Start point of route
    public ProviderTwoPoint Departure { get; set; }


    // Mandatory
    // End point of route
    public ProviderTwoPoint Arrival { get; set; }

    // Mandatory
    // Price of route
    public decimal Price { get; set; }

    // Mandatory
    // Timelimit. After it expires, route became not actual
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime TimeLimit { get; set; }
}
