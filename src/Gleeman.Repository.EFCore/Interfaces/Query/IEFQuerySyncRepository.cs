namespace Gleeman.Repository.EFCore.Interfaces.Query;

public interface IEFQuerySyncRepository<TEntity>
    where TEntity : class
{
    IQueryable<TEntity> Query(bool noTracking,
        Action<Pagination> pagination = null,
        Expression<Func<TEntity, bool>> filter = null,
        params Expression<Func<TEntity, object>>[] includeProperties);

    IEnumerable<TEntity> ReadAll(bool noTracking,
         Action<Pagination> pagination = null,
        Expression<Func<TEntity, bool>> filter = null,
        params Expression<Func<TEntity, object>>[] includeProperties);

    TEntity ReadSingleOrDefault(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] includeProperties);

    TEntity ReadFirstOrDefault(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] includeProperties);

    TEntity ReadLastOrDefault(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
       params Expression<Func<TEntity, object>>[] includeProperties);

    TEntity ReadFirst(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] includeProperties);

    TEntity ReadLast(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] includeProperties);

    TEntity ReadSingle(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] includeProperties);

    bool Exist(Expression<Func<TEntity, bool>> filter);
}
