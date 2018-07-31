using System.Collections.Generic;
using AuctionHouse.Model.ViewModels;

namespace AuctionHouse.Domain.Services.Interfaces
{
    /// <summary>
    ///     The user service.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        ///     Gets user by the login.
        /// </summary>
        /// <param name="login">The user login.</param>
        /// <returns>User details view model.</returns>
        UserDetailsViewModel GetByLogin(string login);

        /// <summary>
        ///     Gets all users.
        /// </summary>
        /// <returns>The list of User details view models.</returns>
        List<UserDetailsViewModel> GetAllUsers();

        /// <summary>
        ///     Register new user.
        /// </summary>
        /// <param name="registerViewModel">The register user view model.</param>
        void RegisterUser(RegisterViewModel registerViewModel);

        /// <summary>
        ///     Gets the user by the login and password.
        /// </summary>
        /// <param name="login">The user login.</param>
        /// <param name="plainPassword">The user password.</param>
        /// <returns></returns>
        UserDetailsViewModel GetByLoginAndPassword(string login, string plainPassword);
    }
}