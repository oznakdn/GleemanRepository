namespace Gleeman.Repository.Dapper.Interfaces.Command.Update
{
    public interface IDapperUpdateSyncRepository<TEntity>
        where TEntity : class
    {
        TEntity Update(TEntity parameter, string sql);
        void Edit(TEntity parameter, string sql);
        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> parameters, string sql);
        void EditRange(IEnumerable<TEntity> parameters, string sql);
    }
}
