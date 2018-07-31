using AuctionHouse.Model.DataModel;

namespace AuctionHouse.DataAccess.Repository.Interfaces
{
    /// <summary>
    ///     The user repository.
    /// </summary>
    public interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        ///     Gets user by the given login.
        /// </summary>
        /// <param name="login">The user login.</param>
        /// <returns><see cref="User"/></returns>
        User GetByLogin(string login);
    }
}