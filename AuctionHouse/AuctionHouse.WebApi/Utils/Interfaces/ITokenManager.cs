namespace AuctionHouse.WebApi.Utils.Interfaces
{
    /// <summary>
    ///     The JWT manager
    /// </summary>
    public interface ITokenManager
    {
        /// <summary>
        ///     Generates a new token for the given login.
        /// </summary>
        /// <param name="login">The user login.</param>
        /// <returns>Authentication token.</returns>
        string GetToken(string login);
    }
}