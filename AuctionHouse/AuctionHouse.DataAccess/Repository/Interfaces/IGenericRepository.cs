using AuctionHouse.Model.DataModel;

namespace AuctionHouse.DataAccess.Repository.Interfaces
{
    /// <summary>
    ///     Base generic repository.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public interface IGenericRepository<T> : IReadOnlyGenericRepository<T>
        where T : BaseEntity
    {
        /// <summary>
        ///     Creates new entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Create(T entity);

        /// <summary>
        ///     Updates existing entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        ///     Deletes existing entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

        /// <summary>
        ///     Saves all changes in the current context.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}