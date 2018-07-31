using AuctionHouse.DataAccess.Repository.Interfaces;
using AuctionHouse.Model.DataModel;

namespace AuctionHouse.DataAccess.Repository.Implementation
{
    /// <summary>
    ///     Base generic repository.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public abstract class GenericRepository<T> : ReadOnlyGenericRepository<T>, IGenericRepository<T>
        where T : BaseEntity
    {
        #region Members
        #endregion

        #region Constructors
        /// <summary>
        ///     Creates an instance of <see cref="GenericRepository{T}"/>
        /// </summary>
        /// <param name="dbContext"></param>
        protected GenericRepository(AuctionHouseDbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region Implementation of IGenericRepository
        /// <summary>
        ///     Creates new entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        /// <summary>
        ///     Updates existing entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        /// <summary>
        ///     Deletes existing entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        /// <summary>
        ///     Saves all changes in the current context.
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
        #endregion
    }
}