namespace Gleeman.Repository.Dapper.Interfaces.Command.Update;

public interface IDapperUpdateAsyncRepository<TEntity>
    where TEntity : class
{
    Task<TEntity> UpdateAsync(TEntity parameter, string sql);
    Task EditAsync(TEntity parameter, string sql);
    Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> parameters, string sql);
    Task EditRangeAsync(IEnumerable<TEntity> parameters, string sql);
}
