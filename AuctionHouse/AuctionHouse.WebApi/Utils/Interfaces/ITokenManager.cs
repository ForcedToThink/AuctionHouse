namespace AuctionHouse.WebApi.Utils.Interfaces
{
    public interface ITokenManager
    {
        string GetToken(string login);
    }
}