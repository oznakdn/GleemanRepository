namespace Gleeman.Repository.EFCore.Interfaces.Command.Update;

public interface IEFUpdateAsyncRepository<TEntity>:IEFAsyncRepository
where TEntity : class
{
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task EditAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    Task EditRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

}
