namespace Gleeman.Repository.Dapper.Interfaces.Query;

public interface IDapperQuerySyncRepository<TEntity>
    where TEntity : class
{
    IEnumerable<TEntity> ReadAll(string sql, Action<Pagination> pagination = null);

    TEntity ReadSingleOrDefault(string sql);

    TEntity ReadFirstOrDefault(string sql);

    TEntity ReadLastOrDefault(string sql);

    TEntity ReadFirst(string sql);

    TEntity ReadLast(string sql);

    TEntity ReadSingle(string sql);
}
