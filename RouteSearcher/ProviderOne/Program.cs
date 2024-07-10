using Common.Converters;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using ProviderOne.Models;
using ProviderOne.Services;

namespace ProviderOne;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
            options.MapType<DateTime>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date",
                Example = new OpenApiString("dd-MM-yyyy H:mm:ss")
            })
        );
        builder.Services.AddDbContext<RouteSearchContext>();
        builder.Services.AddScoped<ISearchService, SearchService>();
        builder.Services.ConfigureHttpJsonOptions(o => o.SerializerOptions.Converters.Add(new JsonDateTimeConverter()));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
