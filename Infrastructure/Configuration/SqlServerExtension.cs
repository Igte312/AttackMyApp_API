﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public static class SqlServerExtension
    {
        public static IServiceCollection AddSqlServiceContext(this IServiceCollection instance, IConfiguration configuration) 
        {
            instance.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return instance;
        }
    }
}
