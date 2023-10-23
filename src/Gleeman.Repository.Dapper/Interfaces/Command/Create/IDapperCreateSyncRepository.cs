namespace Gleeman.Repository.Dapper.Interfaces.Command.Create;

public interface IDapperCreateSyncRepository<TEntity>
{
    TEntity Create(TEntity parameter, string sql);
    void Insert(TEntity parameter, string sql);
    IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> parameters, string sql);
    void InsertRange(IEnumerable<TEntity> parameters, string sql);
}
