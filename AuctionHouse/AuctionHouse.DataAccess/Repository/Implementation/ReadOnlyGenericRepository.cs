using System;
using System.Linq;
using System.Linq.Expressions;
using AuctionHouse.DataAccess.Repository.Interfaces;
using AuctionHouse.Model.DataModel;

namespace AuctionHouse.DataAccess.Repository.Implementation
{
    /// <summary>
    ///     Base generic repository for read only operations.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public abstract class ReadOnlyGenericRepository<T> : IReadOnlyGenericRepository<T>
        where T : BaseEntity
    {
        #region Members
        /// <summary>
        ///     The database context.
        /// </summary>
        protected readonly AuctionHouseDbContext Context;
        #endregion

        #region Constructors
        /// <summary>
        ///     Creates an instance of <see cref="ReadOnlyGenericRepository{T}"/>
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        protected ReadOnlyGenericRepository(AuctionHouseDbContext dbContext)
        {
            Context = dbContext;
        }
        #endregion

        #region Implementation of IReadOnlyGenericRepository
        /// <summary>
        ///     Gets all entities.
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        /// <summary>
        ///     Gets single entity by its identifier.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <returns></returns>
        public T Get(int id)
        {
            return Context.Set<T>().SingleOrDefault(t => t.Id == id);
        }

        /// <summary>
        ///     Searches entities by the specific predicate.
        /// </summary>
        /// <param name="predicate">The search predicate.</param>
        /// <returns></returns>
        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }
        #endregion
    }
}