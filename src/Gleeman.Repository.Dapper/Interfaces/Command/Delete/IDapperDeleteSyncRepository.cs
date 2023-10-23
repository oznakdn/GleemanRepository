namespace Gleeman.Repository.Dapper.Interfaces.Command.Delete;

public interface IDapperDeleteSyncRepository<TEntity>
    where TEntity : class
{
    void Remove(string sql);
    void RemoveRange(string sql);
}
