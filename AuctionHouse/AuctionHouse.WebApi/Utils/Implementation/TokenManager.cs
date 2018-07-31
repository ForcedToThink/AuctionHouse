using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuctionHouse.WebApi.Utils.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuctionHouse.WebApi.Utils.Implementation
{
    /// <summary>
    ///     The JWT manager
    /// </summary>
    public class TokenManager : ITokenManager
    {
        #region Members
        /// <summary>
        ///     The configuration.
        /// </summary>
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructors
        /// <summary>
        ///     Creates an instance of <see cref="TokenManager"/>
        /// </summary>
        /// <param name="configuration"></param>
        public TokenManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region Implementation of ITokenManager
        /// <summary>
        ///     Generates a new token for the given login.
        /// </summary>
        /// <param name="login">The user login.</param>
        /// <returns>Authentication token.</returns>
        public string GetToken(string login)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Issuer"],
                audience: _configuration["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}