using Microsoft.EntityFrameworkCore;

namespace ProviderTwo.Models;

public class RouteSearchContext : DbContext
{
    public DbSet<Route> Routes { get; set; }

    public string DbPath { get; }

    public RouteSearchContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "provider_two.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Route>().HasData(
            new Route
            {
                Id = 1,
                DeparturePoint = "London",
                DepartureDate = new DateTime(2024, 8, 1),
                ArrivalPoint = "Moscow",
                ArrivalDate = new DateTime(2024, 8, 2),
                Price = 100000,
                TimeLimit = new DateTime(2024, 7, 20)
            }
        );

        modelBuilder.Entity<Route>().HasData(
            new Route
            {
                Id = 2,
                DeparturePoint = "Moscow",
                DepartureDate = new DateTime(2024, 8, 1),
                ArrivalPoint = "London",
                ArrivalDate = new DateTime(2024, 8, 2),
                Price = 150000,
                TimeLimit = new DateTime(2024, 7, 20)
            }
        );

        modelBuilder.Entity<Route>().HasData(
            new Route
            {
                Id = 3,
                DeparturePoint = "London",
                DepartureDate = new DateTime(2024, 8, 5),
                ArrivalPoint = "Saint-Petersburg",
                ArrivalDate = new DateTime(2024, 8, 6),
                Price = 150000,
                TimeLimit = new DateTime(2024, 7, 25)
            }
        );

        modelBuilder.Entity<Route>().HasData(
            new Route
            {
                Id = 4,
                DeparturePoint = "Saint-Petersburg",
                DepartureDate = new DateTime(2024, 8, 5),
                ArrivalPoint = "London",
                ArrivalDate = new DateTime(2024, 8, 6),
                Price = 150000,
                TimeLimit = new DateTime(2024, 7, 25)
            }
        );
    }
}
