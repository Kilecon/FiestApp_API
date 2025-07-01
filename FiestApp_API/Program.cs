using FiestApp_Infrastructure.Context;
using FiestApp_Infrastructure.Documents;
using FiestApp_Infrastructure.Repositories.Base;
using FiestApp_Infrastructure.Repositories.UserRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace FiestApp_API;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        const string appName = "FiestApp_API";

        builder.Configuration.AddJsonFile(@"hot.json", false, true);


        builder.Services.Configure<ApplicationDbContext>(builder.Configuration.GetSection("ConnectionStrings"));

        // Configuration de la base de données
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString, b =>
            {
                b.MigrationsAssembly("FiestApp_API_Migrations");
                b.EnableRetryOnFailure(3, TimeSpan.FromSeconds(30), null);
            });

                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();

            });

        // Injection des dépendances
        builder.Services.AddScoped<IRepository<UserDocument>, UserRepository>();
        // Ajoutez d'autres repositories ici

        // Configuration des services
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Configuration CORS si nécessaire
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        builder.Logging.AddOpenTelemetry(options =>
        {
            options
                .SetResourceBuilder(
                    ResourceBuilder.CreateDefault()
                        .AddService(appName))
                .AddConsoleExporter();
        });

        builder.Services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(appName))
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
                .AddConsoleExporter())
            .WithMetrics(metrics => metrics
                .AddAspNetCoreInstrumentation()
                .AddConsoleExporter());

        var app = builder.Build();

        // Configuration du pipeline HTTP
        app.UseSwagger();
        app.UseSwaggerUI();


        app.UseCors("AllowAll");
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}