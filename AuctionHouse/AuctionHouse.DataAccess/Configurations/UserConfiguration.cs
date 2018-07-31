using AuctionHouse.Model.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionHouse.DataAccess.Configurations
{
    /// <summary>
    ///     Entity type configuration for <see cref="User"/>
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        ///     Configure User entity.
        /// </summary>
        /// <param name="builder">The entity type builder for User entity.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Login).IsRequired();
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();

            builder.HasKey(x => x.Id);
        }
    }
}