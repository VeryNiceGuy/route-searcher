
using Common.Converters;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using RouteSearcher.Configuration;
using RouteSearcher.Contracts;
using RouteSearcher.Services;

namespace RouteSearcher
{
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
            builder.Services.AddMemoryCache();
            builder.Services.AddScoped<ISearchService, SearchService>();
            builder.Services.ConfigureHttpJsonOptions(o => o.SerializerOptions.Converters.Add(new JsonDateTimeConverter()));

            var section = builder.Configuration.GetSection("ProviderConfig");
            var providerConfig = section.Get<ProviderConfig>();

            if (providerConfig != null)
            {
                builder.Services.AddSingleton(providerConfig);
            }

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
}
