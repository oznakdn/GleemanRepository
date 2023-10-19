namespace Gleeman.Repository.EFCore.Interfaces.Command.Create;

public interface IEFCreateSyncRepository<TEntity> : IEFSyncRepository
where TEntity : class
{
    TEntity Create(TEntity entity);
    void Insert(TEntity entity);
    IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entities);
    void InsertRange(IEnumerable<TEntity> entities);
}
