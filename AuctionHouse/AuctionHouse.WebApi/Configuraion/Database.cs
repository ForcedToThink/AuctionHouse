using System;
using System.Linq;
using System.Reflection;
using AuctionHouse.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionHouse.WebApi.Configuraion
{
    /// <summary>
    ///     Configures database.
    /// </summary>
    public static class Database
    {
        private const string DefaultConnectionName = "AuctionHouse";

        /// <summary>
        ///     Adds database to service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The application configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(DefaultConnectionName);

            services.AddDbContext<AuctionHouseDbContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}