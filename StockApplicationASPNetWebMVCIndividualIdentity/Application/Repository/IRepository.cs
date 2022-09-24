using System.Linq.Expressions;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

internal interface IRepository<TEntity> where TEntity : class  
    {  
        IEnumerable<TEntity> Get(  
           Expression<Func<TEntity, bool>> filter,  
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,  
           string? includeProperties = "");  
  
        /// <summary>  
        /// Gets the specified identifier.  
        /// </summary>  
        /// <param name="id">The identifier.</param>  
        /// <returns></returns>  
        TEntity Get(long id);  
  
        /// <summary>  
        /// Gets all.  
        /// </summary>  
        /// <returns></returns>  
        IEnumerable<TEntity> GetAll();  
  
        /// <summary>  
        /// Finds the specified predicate.  
        /// </summary>  
        /// <param name="predicate">The predicate.</param>  
        /// <returns></returns>  
        IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);  
  
        /// <summary>  
        /// Singles the or default.  
        /// </summary>  
        /// <param name="predicate">The predicate.</param>  
        /// <returns></returns>  
        TEntity SingleOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);  
  
        /// <summary>  
        /// First the or default.  
        /// </summary>  
        /// <returns></returns>  
        TEntity FirstOrDefault();  
  
        /// <summary>  
        /// Adds the specified entity.  
        /// </summary>  
        /// <param name="entity">The entity.</param>  
        void Add(TEntity entity);  
  
        /// <summary>  
        /// Adds the range.  
        /// </summary>  
        /// <param name="entities">The entities.</param>  
        void AddRange(IEnumerable<TEntity> entities);  
  
        /// <summary>  
        /// Removes the specified entity.  
        /// </summary>  
        /// <param name="entity">The entity.</param>  
        void Remove(TEntity entity);  
  
        /// <summary>  
        /// Removes the range.  
        /// </summary>  
        /// <param name="entities">The entities.</param>  
        void RemoveRange(IEnumerable<TEntity> entities);  
  
        /// <summary>  
        /// Removes the Entity  
        /// </summary>  
        /// <param name="entityToDelete"></param>  
        void RemoveEntity(TEntity entityToDelete);  
  
        /// <summary>  
        /// Update the Entity  
        /// </summary>  
        /// <param name="entityToUpdate"></param>  
        void UpdateEntity(TEntity entityToUpdate);  
  
    }  