namespace Gleeman.Repository.Dapper.Interfaces.Command.Create;

public interface IDapperCreateAsyncRepository<TEntity>
    where TEntity : class
{
    Task<TEntity> CreateAsync(TEntity parameter, string sql);
    Task InsertAsync(TEntity parameter, string sql);
    Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> parameters, string sql);
    Task InsertRangeAsync(IEnumerable<TEntity> parameters, string sql);
}
