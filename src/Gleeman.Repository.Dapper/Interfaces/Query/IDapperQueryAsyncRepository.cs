namespace Gleeman.Repository.Dapper.Interfaces.Query;

public interface IDapperQueryAsyncRepository<TEntity>
    where TEntity : class
{

    Task<IEnumerable<TEntity>> ReadAllAsync(string sql, Action<Pagination> pagination = null);

    Task<TEntity> ReadSingleOrDefaultAsync(string sql);

    Task<TEntity> ReadFirstOrDefaultAsync(string sql);

    Task<TEntity> ReadLastOrDefaultAsync(string sql);

    Task<TEntity> ReadFirstAsync(string sql);

    Task<TEntity> ReadLastAsync(string sql);

    Task<TEntity> ReadSingleAsync(string sql);
}
