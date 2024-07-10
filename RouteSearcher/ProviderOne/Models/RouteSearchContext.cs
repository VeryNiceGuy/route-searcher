using Microsoft.EntityFrameworkCore;

namespace ProviderOne.Models;

public class RouteSearchContext : DbContext
{
    public DbSet<Route> Routes { get; set; }

    public string DbPath { get; }

    public RouteSearchContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "provider_one.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Route>().HasData(
            new Route
            {
                Id = 1,
                From = "London",
                DateFrom = new DateTime(2024, 8, 1),
                To = "Moscow",
                DateTo = new DateTime(2024, 8, 3),
                Price = 80000,
                TimeLimit = new DateTime(2024, 7, 25)
            }
        );

        modelBuilder.Entity<Route>().HasData(
            new Route
            {
                Id = 2,
                From = "Moscow",
                DateFrom = new DateTime(2024, 8, 1),
                To = "London",
                DateTo = new DateTime(2024, 8, 3),
                Price = 50000,
                TimeLimit = new DateTime(2024, 7, 25)
            }
        );

        modelBuilder.Entity<Route>().HasData(
            new Route
            {
                Id = 3,
                From = "London",
                DateFrom = new DateTime(2024, 8, 5),
                To = "Saint-Petersburg",
                DateTo = new DateTime(2024, 8, 7),
                Price = 120000,
                TimeLimit = new DateTime(2024, 7, 25)
            }
        );

        modelBuilder.Entity<Route>().HasData(
            new Route
            {
                Id = 4,
                From = "Saint-Petersburg",
                DateFrom = new DateTime(2024, 8, 5),
                To = "London",
                DateTo = new DateTime(2024, 8, 7),
                Price = 90000,
                TimeLimit = new DateTime(2024, 7, 25)
            }
        );
    }
}
