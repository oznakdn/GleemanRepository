namespace Gleeman.Repository.EFCore.Interfaces.Command.Delete;

public interface IEFDeleteAsyncRepository<TEntity>:IEFAsyncRepository
    where TEntity : class
{
    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
    Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
    Task<IEnumerable<TEntity>> DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
    Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));

}
