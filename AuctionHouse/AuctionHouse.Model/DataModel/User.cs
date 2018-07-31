namespace AuctionHouse.Model.DataModel
{
    /// <summary>
    ///     The user entity.
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        ///     The user login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        ///     The user first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///  The user last name.
        /// </summary>
        public string LastName { get; set; }
    }
}