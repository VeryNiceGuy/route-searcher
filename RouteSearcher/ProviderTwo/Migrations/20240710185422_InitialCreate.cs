using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProviderTwo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeparturePoint = table.Column<string>(type: "TEXT", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ArrivalPoint = table.Column<string>(type: "TEXT", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    TimeLimit = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "ArrivalDate", "ArrivalPoint", "DepartureDate", "DeparturePoint", "Price", "TimeLimit" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moscow", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "London", 100000m, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "London", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moscow", 150000m, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint-Petersburg", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "London", 150000m, new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "London", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint-Petersburg", 150000m, new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
