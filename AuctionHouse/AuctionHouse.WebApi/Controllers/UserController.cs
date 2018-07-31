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
        [ProducesResponseType(typeof(UserViewModel), 200)]
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
        [ProducesResponseType(typeof(List<UserViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            var users = _userService.GetAllUsers();

            return Ok(users);
        }

        /// <summary>
        ///     Create user.
        /// </summary>
        /// <remarks>Creates new user.</remarks>
        /// <param name="user">The user view model.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Create([FromBody] UserViewModel user)
        {
            _userService.CreateUser(user);
            return Ok();
        }

        /// <summary>
        ///     Update user.
        /// </summary>
        /// <remarks>Updates existing user.</remarks>
        /// <param name="user">The user view model.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Update([FromBody] UserViewModel user)
        {
            _userService.UpdateUser(user);
            return Ok();
        }

        /// <summary>
        ///     Delete user.
        /// </summary>
        /// <remarks>Deletes existing user.</remarks>
        /// <param name="id">The user identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
        #endregion
    }
}