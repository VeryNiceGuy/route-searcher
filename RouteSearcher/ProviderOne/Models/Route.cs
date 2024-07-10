namespace ProviderOne.Models;

public class Route
{
    public int Id { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public decimal Price { get; set; }
    public DateTime TimeLimit { get; set; }
}
