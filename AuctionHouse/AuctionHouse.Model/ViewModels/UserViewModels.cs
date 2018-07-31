namespace AuctionHouse.Model.ViewModels
{
    /// <summary>
    ///     The User view model.
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        ///     The identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The user login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        ///     The user first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     The user last name.
        /// </summary>
        public string LastName { get; set; }
    }

    /// <summary>
    ///     User details view model.
    /// </summary>
    public class UserDetailsViewModel
    {
        /// <summary>
        ///     The identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The user login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        ///     The user first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     The user last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     The user full name.
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";
    }
}