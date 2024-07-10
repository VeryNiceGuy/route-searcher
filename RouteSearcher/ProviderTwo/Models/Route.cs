namespace ProviderTwo.Models;

public class Route
{
    public int Id { get; set; }
    public string DeparturePoint { get; set; }
    public DateTime DepartureDate { get; set; }
    public string ArrivalPoint { get; set; }
    public DateTime ArrivalDate { get; set; }
    public decimal Price { get; set; }
    public DateTime TimeLimit { get; set; }
}
