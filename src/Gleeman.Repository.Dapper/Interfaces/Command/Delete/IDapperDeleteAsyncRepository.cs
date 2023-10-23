namespace Gleeman.Repository.Dapper.Interfaces.Command.Delete;

public interface IDapperDeleteAsyncRepository<TEntity>
    where TEntity : class
{
    Task RemoveAsync(string sql);
    Task RemoveRangeAsync(string sql);
}
