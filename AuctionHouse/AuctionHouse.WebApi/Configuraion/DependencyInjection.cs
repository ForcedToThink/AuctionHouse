using AuctionHouse.DataAccess.Repository.Implementation;
using AuctionHouse.DataAccess.Repository.Interfaces;
using AuctionHouse.Domain.Services.Implementation;
using AuctionHouse.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionHouse.WebApi.Configuraion
{
    /// <summary>
    ///     Add dependency injection to service collection.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        ///     Add dependencies to service collecion.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            // register repositories
            services.AddScoped<IUserRepository, UserRepository>();

            // register services
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}