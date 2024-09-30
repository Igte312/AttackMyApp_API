using Aplication.InterfaceService;
using Aplication.Service;
using Aplication.Utilities.Interface;
using Aplication.Utilities.Service;
using Domain.InterfaceRepository;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public static class ServiceRepositoryInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register Repositories
            services.AddScoped<IUserRepository, UsersRepository>();
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();

            // Register Services
            services.AddScoped<IUsersService, UserService>();
            services.AddScoped<IUserTypeService, UserTypeService>();
            services.AddScoped<IHashUtilService, HashUtilService>();

            return services;
        }
    }
}
