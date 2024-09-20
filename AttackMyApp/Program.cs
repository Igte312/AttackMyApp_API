using Microsoft.Extensions.FileProviders;
using Infrastructure.Configuration;
using Domain.Models;
using Aplication.Service;
using Domain.InterfaceRepository;
using Aplication.InterfaceService;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
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
            var configuration = builder.Configuration;

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
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // Obtener la cadena de conexión del archivo appsettings.json
            var connectionStringTemplate = builder.Configuration.GetConnectionString("DefaultConnection");

            // Reemplazar las variables de entorno en la cadena de conexión
            var connectionString = connectionStringTemplate
                .Replace("${DB_HOST}", Environment.GetEnvironmentVariable("DB_HOST") ?? "default_host")
                .Replace("${DB_NAME}", Environment.GetEnvironmentVariable("DB_NAME") ?? "default_db")
                .Replace("${DB_PORT}", Environment.GetEnvironmentVariable("DB_PORT") ?? "5432")
                .Replace("${DB_USER}", Environment.GetEnvironmentVariable("DB_USER") ?? "default_user")
                .Replace("${DB_PASSWORD}", Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "default_password");

            // Configurar DbContext con la cadena de conexión final
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            //builder.Services.AddSqlServiceContext(configuration);

            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


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
