namespace Gleeman.Repository.EFCore.Interfaces.Command.Delete;

public interface IEFDeleteSyncRepository<TEntity>:IEFSyncRepository
    where TEntity : class
{
    TEntity Delete(TEntity entity);
    void Remove(TEntity entity);
    IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entities);
    void RemoveRange(IEnumerable<TEntity> entities);

}
