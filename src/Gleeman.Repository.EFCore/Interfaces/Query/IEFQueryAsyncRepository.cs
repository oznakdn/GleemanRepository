namespace Gleeman.Repository.EFCore.Interfaces.Query;

public interface IEFQueryAsyncRepository<TEntity>
where TEntity : class
{
    Task<IQueryable<TEntity>> QueryAsync(bool noTracking,
        Action<Pagination> pagination = null,
        Expression<Func<TEntity, bool>> filter = null,
        CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<TEntity, object>>[] includeProperties);

    Task<IEnumerable<TEntity>> ReadAllAsync(bool noTracking,
        Action<Pagination> pagination = null,
        Expression<Func<TEntity, bool>> filter = null,
        CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<TEntity, object>>[] includeProperties);

    Task<TEntity> ReadSingleOrDefaultAsync(bool noTracking,Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<TEntity, object>>[] includeProperties);

    Task<TEntity> ReadFirstOrDefaultAsync(bool noTracking,Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<TEntity, object>>[] includeProperties);

    Task<TEntity> ReadLastOrDefaultAsync(bool noTracking, Expression<Func<TEntity, bool>> filter,
       CancellationToken cancellationToken = default(CancellationToken),
       params Expression<Func<TEntity, object>>[] includeProperties);

    Task<TEntity> ReadFirstAsync(bool noTracking,Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<TEntity, object>>[] includeProperties);

    Task<TEntity> ReadLastAsync(bool noTracking,Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<TEntity, object>>[] includeProperties);

    Task<TEntity> ReadSingleAsync(bool noTracking,Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<TEntity, object>>[] includeProperties);

    Task<bool> ExistAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default(CancellationToken));
}
