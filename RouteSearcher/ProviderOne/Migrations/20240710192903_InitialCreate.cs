using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProviderOne.Migrations
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
                    From = table.Column<string>(type: "TEXT", nullable: false),
                    To = table.Column<string>(type: "TEXT", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateTo = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    TimeLimit = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "DateFrom", "DateTo", "From", "Price", "TimeLimit", "To" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "London", 80000m, new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moscow" },
                    { 2, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moscow", 50000m, new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "London" },
                    { 3, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "London", 120000m, new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint-Petersburg" },
                    { 4, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint-Petersburg", 90000m, new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "London" }
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
