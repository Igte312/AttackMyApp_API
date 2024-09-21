using Domain.Models;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Infrastructure.Configuration;

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
                    corsBuilder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            
            // Configurar DbContext con la cadena de conexión final
            var connectionString = DatabaseConfig.GetConnectionString();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            //Services and Repositories
            builder.Services.AddApplicationServices();

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
