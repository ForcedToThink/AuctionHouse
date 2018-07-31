using System.Collections.Generic;
using AuctionHouse.Domain.Services.Interfaces;
using AuctionHouse.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AuctionHouse.WebApi.Controllers
{
    /// <summary>
    ///     The user controller
    ///     Handles user actions.
    /// </summary>
    public class UserController : BaseController
    {
        #region Members
        /// <summary>
        ///     The user service.
        /// </summary>
        private readonly IUserService _userService;
        #endregion

        #region Constructors
        /// <summary>
        ///     Creates an instance of <see cref="UserController"/>
        /// </summary>
        /// <param name="userService">The user service.</param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Controller Actions
        /// <summary>
        ///     Get user.
        /// </summary>
        /// <remarks>Gets user by the specific login.</remarks>
        /// <param name="login">The user login.</param>
        /// <returns></returns>
        [HttpGet("{login}")]
        [ProducesResponseType(typeof(UserDetailsViewModel), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get(string login)
        {
            var user = _userService.GetByLogin(login);
            return Ok(user);
        }

        /// <summary>
        ///     Get all users.
        /// </summary>
        /// <remarks>Gets all users.</remarks>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<UserDetailsViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            var users = _userService.GetAllUsers();

            return Ok(users);
        }

        /// <summary>
        ///     Get current user.
        /// </summary>
        /// <remarks>Gets currently logged in user.</remarks>
        /// <returns></returns>
        [HttpGet("current")]
        [ProducesResponseType(typeof(UserDetailsViewModel), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetCurrent()
        {
            var user = _userService.GetByLogin(User.Identity.Name);
            return Ok(user);
        }
        #endregion
    }
}