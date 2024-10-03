using Amplifund.Assignment.Data.Repository.Common;
using Amplifund.Assignment.Data.Repository.Grant;
using Amplifund.Assignment.Domain;
using Amplifund.Assignment.Domain.IRepository.Common;
using Amplifund.Assignment.Domain.IRepository.Grant;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amplifund.Assignment.Data
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureDataBase(this IServiceCollection services, string connectionString)
        {
            //https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
            services.AddDbContext<AppDbContext>(provider =>
            {
                provider.UseSqlite(connectionString);
            });
        }

        public static IServiceCollection AddAppData(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Common 
            services.AddTransient<IStateRepository, StateRepository>();

            // Grant
            services.AddTransient<IGrantRepository, GrantRepository>();
            services.AddTransient<IStateGrantRepository, StateGrantRepository>();

            return services;
        }
    }
}
