using System.Net.Security;
using System.Reflection;
using AuctionHouse.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AuctionHouse.DataAccess
{
    /// <summary>
    ///     Default AuctionHouse database conext.
    /// </summary>
    public class AuctionHouseDbContext : DbContext
    {
        /// <summary>
        ///     Creates an instance of <see cref="AuctionHouseDbContext"/>
        /// </summary>
        /// <param name="options">The database context options.</param>
        public AuctionHouseDbContext(DbContextOptions<AuctionHouseDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}