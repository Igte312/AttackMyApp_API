using Domain.Models;
using Aplication.Service;
using Domain.InterfaceRepository;
using Aplication.InterfaceService;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace AttackMyApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Cargar las variables de entorno desde el archivo .env antes de crear el builder
            Env.Load();

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", corsBuilder =>
                {
                    corsBuilder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Construir la cadena de conexión usando variables de entorno
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "default_host";
            var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "default_db";
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
            var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "default_user";
            var dbPass = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "default_password";

            // Crear la cadena de conexión
            var connectionString = $"Host={dbHost};Database={dbName};Port={dbPort};Username={dbUser};Password={dbPass};";

            // Configurar DbContext con la cadena de conexión final
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            // Register Repositories
            builder.Services.AddScoped<IUserRepository, UsersRepository>();

            // Register Services
            builder.Services.AddScoped<IUsersService, UserService>();

            builder.Services.AddHttpClient();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("EnableCORS");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
