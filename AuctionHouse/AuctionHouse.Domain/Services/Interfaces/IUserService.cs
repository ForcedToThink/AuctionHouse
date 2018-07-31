﻿using System.Collections.Generic;
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
        /// <returns>User view model.</returns>
        UserViewModel GetByLogin(string login);

        /// <summary>
        ///     Gets all users.
        /// </summary>
        /// <returns>The list of User view models.</returns>
        List<UserViewModel> GetAllUsers();

        /// <summary>
        ///     Creates new user.
        /// </summary>
        /// <param name="userViewModel">The user view model.</param>
        void CreateUser(UserViewModel userViewModel);

        /// <summary>
        ///     Updates the user.
        /// </summary>
        /// <param name="userViewModel">The user view model.</param>
        void UpdateUser(UserViewModel userViewModel);

        /// <summary>
        ///     Deletes the user.
        /// </summary>
        /// <param name="id">The user identifer.</param>
        void DeleteUser(int id);
    }
}