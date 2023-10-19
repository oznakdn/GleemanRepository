namespace Gleeman.Repository.EFCore.Interfaces.Command.Create;

public interface IEFCreateAsyncRepository<TEntity> : IEFAsyncRepository
where TEntity : class
{
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
    Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
    Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
    Task InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));

}
