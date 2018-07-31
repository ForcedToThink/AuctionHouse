using AuctionHouse.DataAccess.Repository.Interfaces;
using AuctionHouse.Model.DataModel;

namespace AuctionHouse.DataAccess.Repository.Implementation
{
    /// <summary>
    ///     The user repository.
    /// </summary>
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        #region Constructors
        /// <summary>
        ///     Creates an instance of <see cref="UserRepository"/>
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public UserRepository(AuctionHouseDbContext dbContext) : base(dbContext)
        {
        }
        #endregion
    }
}