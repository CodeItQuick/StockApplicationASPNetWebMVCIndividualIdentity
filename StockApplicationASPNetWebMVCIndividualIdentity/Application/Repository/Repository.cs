using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public class Repository<TEntity>: IRepository<TEntity> where TEntity : class
{
    public DbSet<TEntity> Entities { get; set; } 
    private readonly DbContext _dbContext;  
  
    /// <summary>  
    /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.  
    /// Note that here I've stored Context.Set<TEntity>() in the constructor and store it in a private field like _entities.   
    /// This way, the implementation  of our methods would be cleaner:        ///   
    /// _entities.ToList();  
    /// _entities.Where();  
    /// _entities.SingleOrDefault();  
    /// </summary>  
    public Repository(DbContext dbContext)  
    {  
        _dbContext = dbContext;  
        Entities = _dbContext.Set<TEntity>();  
    }

    protected Repository()
    {
        // for tests
    }

    public virtual IEnumerable<TEntity> Get(  
        Expression<Func<TEntity, bool>> filter,  
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,  
        string? includeProperties = "")  
    {  
        IQueryable<TEntity> query = Entities;  
  
        if (filter != null)  
        {  
            query = query.Where(filter);  
        }  
  
        foreach (var includeProperty in includeProperties.Split  
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))  
        {  
            query = query.Include(includeProperty);  
        }  
  
        if (orderBy != null)  
        {  
            return orderBy(query).ToList();  
        }  
        else  
        {  
            return query.ToList();  
        }  
    }  
  
  
    /// <summary>  
    /// Gets the specified identifier.  
    /// </summary>  
    /// <param name="id">The identifier.</param>  
    /// <returns></returns>  
    public virtual TEntity Get(long id)  
    {  
        // Here we are working with a DbContext, not specific DbContext.   
        // So we don't have DbSets we need to use the generic Set() method to access them.  
        return Entities.Find(id);  
    }  
  
    /// <summary>  
    /// Gets all.  
    /// </summary>  
    /// <returns></returns>  
    public IEnumerable<TEntity> GetAll()  
    {  
        return Entities.ToList();  
    }  
  
    /// <summary>  
    /// Finds the specified predicate.  
    /// </summary>  
    /// <param name="predicate">The predicate.</param>  
    /// <returns></returns>  
    public IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)  
    {  
        return Entities.Where(predicate);  
    }  
  
    /// <summary>  
    /// Singles the or default.  
    /// </summary>  
    /// <param name="predicate">The predicate.</param>  
    /// <returns></returns>  
    public TEntity SingleOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)  
    {  
        return Entities.Where(predicate).SingleOrDefault();  
    }  
  
    /// <summary>  
    /// First the or default.  
    /// </summary>  
    /// <returns></returns>  
    public TEntity FirstOrDefault()  
    {  
        return Entities.SingleOrDefault();  
    }  
  
    /// <summary>  
    /// Adds the specified entity.  
    /// </summary>  
    /// <param name="entity">The entity.</param>  
    public void Add(TEntity entity)  
    {  
        Entities.Add(entity);
    }  
  
    /// <summary>  
    /// Adds the range.  
    /// </summary>  
    /// <param name="entities">The entities.</param>  
    public void AddRange(IEnumerable<TEntity> entities)  
    {  
        Entities.AddRange(entities);  
    }  
    /// <summary>  
    /// Adds the range.  
    /// </summary>  
    /// <param name="entities">The entities.</param>  
    public Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        Entities.AddRangeAsync(entities);
        return Task.CompletedTask;
    }  
  
    /// <summary>  
    /// Removes the specified entity.  
    /// </summary>  
    /// <param name="entity">The entity.</param>  
    public void Remove(TEntity entity)  
    {  
        Entities.Remove(entity);  
    }  
  
    /// <summary>  
    /// Removes the range.  
    /// </summary>  
    /// <param name="entities">The entities.</param>  
    public void RemoveRange(IEnumerable<TEntity> entities)  
    {  
        Entities.RemoveRange(entities);  
    }  
  
  
    /// <summary>  
    /// Removes the Entity  
    /// </summary>  
    /// <param name="entityToDelete"></param>  
    public virtual void RemoveEntity(TEntity entityToDelete)  
    {
        Entities.Remove(entityToDelete);  
          
    }  
  
    /// <summary>  
    /// Update the Entity  
    /// </summary>  
    /// <param name="entityToUpdate"></param>  
    public virtual void UpdateEntity(TEntity entityToUpdate)
    {
        Entities.Update(entityToUpdate);
    }

    public virtual IQueryable<TEntity> Query(Expression<Func<IQueryable<TEntity>>> sqlQuery)
    {
        return _dbContext.FromExpression<TEntity>(sqlQuery);
    }
}  