﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProviderTwo.Models;

#nullable disable

namespace ProviderTwo.Migrations
{
    [DbContext(typeof(RouteSearchContext))]
    [Migration("20240710185422_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("ProviderTwo.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ArrivalPoint")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeparturePoint")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeLimit")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Routes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArrivalDate = new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ArrivalPoint = "Moscow",
                            DepartureDate = new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeparturePoint = "London",
                            Price = 100000m,
                            TimeLimit = new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            ArrivalDate = new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ArrivalPoint = "London",
                            DepartureDate = new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeparturePoint = "Moscow",
                            Price = 150000m,
                            TimeLimit = new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            ArrivalDate = new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ArrivalPoint = "Saint-Petersburg",
                            DepartureDate = new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeparturePoint = "London",
                            Price = 150000m,
                            TimeLimit = new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            ArrivalDate = new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ArrivalPoint = "London",
                            DepartureDate = new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeparturePoint = "Saint-Petersburg",
                            Price = 150000m,
                            TimeLimit = new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
