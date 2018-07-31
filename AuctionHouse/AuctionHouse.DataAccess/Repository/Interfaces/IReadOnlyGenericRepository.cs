using System;
using System.Linq;
using System.Linq.Expressions;
using AuctionHouse.Model.DataModel;

namespace AuctionHouse.DataAccess.Repository.Interfaces
{
    /// <summary>
    ///     Base generic repository for read only operations.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public interface IReadOnlyGenericRepository<T>
        where T : BaseEntity
    {
        /// <summary>
        ///     Gets all entities.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        ///     Gets single entity by its identifier.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        ///     Searches entities by the specific predicate.
        /// </summary>
        /// <param name="predicate">The search predicate.</param>
        /// <returns></returns>
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    }
}