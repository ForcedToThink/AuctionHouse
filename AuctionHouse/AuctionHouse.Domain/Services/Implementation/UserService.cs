using System.Collections.Generic;
using System.Linq;
using AuctionHouse.DataAccess.Repository.Interfaces;
using AuctionHouse.Domain.Services.Interfaces;
using AuctionHouse.Model.DataModel;
using AuctionHouse.Model.ViewModels;

namespace AuctionHouse.Domain.Services.Implementation
{
    /// <summary>
    ///     The user service.
    /// </summary>
    public sealed class UserService : BaseService, IUserService
    {
        #region Members
        /// <summary>
        ///     The user repository.
        /// </summary>
        private readonly IUserRepository _userRepository;
        #endregion

        #region Constructors
        /// <summary>
        ///     Creates an instance of <see cref="UserService"/>
        /// </summary>
        /// <param name="userRepository"></param>
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Implementation of IUserService
        /// <summary>
        ///     Gets user by the login.
        /// </summary>
        /// <param name="login">The user login.</param>
        /// <returns>User view model.</returns>
        public UserViewModel GetByLogin(string login)
        {
            var user = _userRepository.GetAll()
                .SingleOrDefault(u => u.Login.ToLowerInvariant().Equals(login.ToLowerInvariant()));

            return user == null ? null : new UserViewModel {Id = user.Id, Login = user.Login};
        }

        /// <summary>
        ///     Gets all users.
        /// </summary>
        /// <returns>The list of User view models.</returns>
        public List<UserViewModel> GetAllUsers()
        {
            var users = _userRepository.GetAll().ToList();
            var result = users.Select(u => new UserViewModel {Id = u.Id, Login = u.Login});

            return result.ToList();
        }

        /// <summary>
        ///     Creates new user.
        /// </summary>
        /// <param name="userViewModel">The user view model.</param>
        public void CreateUser(UserViewModel userViewModel)
        {
            var user = new User {Id = userViewModel.Id, Login = userViewModel.Login};
            _userRepository.Create(user);
            _userRepository.SaveChanges();
        }

        /// <summary>
        ///     Updates the user.
        /// </summary>
        /// <param name="userViewModel">The user view model.</param>
        public void UpdateUser(UserViewModel userViewModel)
        {
            var user = _userRepository.Get(userViewModel.Id);
            if (user != null)
            {
                user.Login = userViewModel.Login;
                _userRepository.Update(user);
                _userRepository.SaveChanges();
            }
        }

        /// <summary>
        ///     Deletes the user.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        public void DeleteUser(int id)
        {
            var user = _userRepository.Get(id);
            if (user != null)
            {
                _userRepository.Delete(user);
                _userRepository.SaveChanges();
            }
        }
        
        #endregion
    }
}