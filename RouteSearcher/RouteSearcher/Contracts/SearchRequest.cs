using Common.Converters;
using System.Text.Json.Serialization;

namespace RouteSearcher.Contracts;

public class SearchRequest
{
    // Mandatory
    // Start point of route, e.g. Moscow 
    public string Origin { get; set; }

    // Mandatory
    // End point of route, e.g. Sochi
    public string Destination { get; set; }

    // Mandatory
    // Start date of route
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime OriginDateTime { get; set; }

    // Optional
    public SearchFilters? Filters { get; set; }

    public override int GetHashCode()
    {
        var hashCode = Origin.GetHashCode() ^ Destination.GetHashCode() ^ OriginDateTime.GetHashCode();

        if(Filters != null)
        {
            if(Filters.DestinationDateTime != null)
            {
                hashCode ^= Filters.DestinationDateTime.GetHashCode();
            }

            if(Filters.MaxPrice != null)
            {
                hashCode ^= Filters.MaxPrice.GetHashCode();
            }

            if(Filters.MinTimeLimit != null)
            {
                hashCode ^= Filters.MinTimeLimit.GetHashCode();
            }
        }

        return hashCode;
    }

    public override bool Equals(object? obj)
    {
        if(obj == null)
        {
            return false;
        }

        var searchRequest = (SearchRequest)obj;

        if(Origin == searchRequest.Origin && Destination == searchRequest.Destination && OriginDateTime == searchRequest.OriginDateTime)
        {
            if(Filters == null && searchRequest.Filters == null)
            {
                return true;
            }
            else if(Filters != null && searchRequest.Filters != null)
            {
                if(
                    Filters.MinTimeLimit == searchRequest.Filters.MinTimeLimit
                    && Filters.DestinationDateTime == searchRequest.Filters.DestinationDateTime
                    && Filters.MaxPrice == searchRequest.Filters.MaxPrice)
                {
                    return true;
                }
            }
        }

        return false;
    }
}