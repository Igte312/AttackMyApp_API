﻿using Aplication.InterfaceService;
using Aplication.Service;
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

            // Register Services
            services.AddScoped<IUsersService, UserService>();

            return services;
        }
    }
}
