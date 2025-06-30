using FiestApp_Infrastructure.Context;
using FiestApp_Infrastructure.Documents;
using FiestApp_Infrastructure.Repositories.Base;
using FiestApp_Infrastructure.Repositories.UsersRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace FiestApp_API
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile(@"hot.json", optional: false, reloadOnChange: true);


            builder.Services.Configure<ApplicationDbContext>(builder.Configuration.GetSection("ConnectionStrings"));

            // Configuration de la base de données
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString, b =>
                {
                    b.MigrationsAssembly("FiestApp_API_Migrations");
                    b.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                });

                // Configuration pour le développement
                if (builder.Environment.IsDevelopment())
                {
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }
            });

            // Injection des dépendances
            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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
}
