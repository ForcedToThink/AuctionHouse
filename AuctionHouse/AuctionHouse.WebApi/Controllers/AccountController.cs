using System;
using AuctionHouse.Domain.Services.Interfaces;
using AuctionHouse.Model.ViewModels;
using AuctionHouse.WebApi.Utils.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionHouse.WebApi.Controllers
{
    /// <summary>
    ///     The account controller.
    /// </summary>
    public class AccountController : BaseController
    {
        #region Members
        /// <summary>
        ///     The user service.
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        ///     The token menager.
        /// </summary>
        private readonly ITokenManager _tokenManager;
        #endregion

        #region Constructors
        /// <summary>
        ///     Creates an instance of <see cref="AccountController"/>
        /// </summary>
        /// <param name="userService">The user service.</param>
        /// <param name="tokenManager">The token menager.</param>
        public AccountController(IUserService userService, ITokenManager tokenManager)
        {
            _userService = userService;
            _tokenManager = tokenManager;
        }
        #endregion

        #region Controller actions
        /// <summary>
        ///     Register user.
        /// </summary>
        /// <remarks>Registers new user.</remarks>
        /// <param name="model">The register user view model.</param>
        /// <returns></returns>
        [HttpPost("register")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Register([FromBody] RegisterViewModel model)
        {
            try
            {
                var user =_userService.RegisterUser(model);
                user.AuthenticationToken = _tokenManager.GetToken(model.Login);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        ///     Login user.
        /// </summary>
        /// <remarks>Login user.</remarks>
        /// <param name="model">The login user view model.</param>
        /// <returns></returns>
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            var user = _userService.GetByLoginAndPassword(model.Login, model.Password);
            if (user != null)
            {
                user.AuthenticationToken = _tokenManager.GetToken(user.Login);
                return Ok(user);
            }

            return BadRequest("Invalid username or password.");
        }
        #endregion
    }
}