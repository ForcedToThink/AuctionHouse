namespace AuctionHouse.Model.ViewModels
{
    /// <summary>
    ///     The registration view model.
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        ///     The user login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        ///     The user password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     The user first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     The user last name.
        /// </summary>
        public string LastName { get; set; }
    }
}