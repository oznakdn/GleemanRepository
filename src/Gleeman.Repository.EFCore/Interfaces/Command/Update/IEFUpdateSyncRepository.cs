namespace Gleeman.Repository.EFCore.Interfaces.Command.Update;

public interface IEFUpdateSyncRepository<TEntity>:IEFSyncRepository
where TEntity : class
{
    TEntity Update(TEntity entity);
    void Edit(TEntity entity);
    IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);
    void EditRange(IEnumerable<TEntity> entities);

}
