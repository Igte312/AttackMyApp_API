
using Microsoft.Extensions.FileProviders;
using Infrastructure.Configuration;
using Domain.Models;
using Aplication.Service;
using Domain.InterfaceRepository;
using Aplication.InterfaceService;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace AttackMyApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
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

            builder.Services.AddSqlServiceContext(configuration);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register Repositories
            builder.Services.AddScoped<IUserRepository, UsersRepository>();

            // Register Services
            builder.Services.AddScoped<IUsersService, UserService>();



            //builder.Services.AddServices();
            //builder.Services.AddRepositories();
                //builder.Services.AddJwtAuthentication(configuration);
            builder.Services.AddHttpClient();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //if (app.Environment.IsDevelopment() || app.Environment.IsProduction() || app.Environment.IsEnvironment("QA"))
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseCors("EnableCORS");

            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(), "Public")),
            //    RequestPath = "/Public"
            //});

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseMiddleware<AuthorizationMiddleware>();

            app.MapControllers();

            app.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
                webBuilder.UseUrls($"http://0.0.0.0:{port}");
                webBuilder.UseStartup<Startup>();
            });
    }
}

