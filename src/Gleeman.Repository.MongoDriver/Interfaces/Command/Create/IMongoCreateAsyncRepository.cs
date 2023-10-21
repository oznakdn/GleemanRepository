namespace Gleeman.Repository.MongoDriver.Interfaces.Command.Create;

public interface IMongoCreateAsyncRepository<TCollection>
    where TCollection : class
{
    Task<TCollection> CreateAsync(TCollection document, CancellationToken cancellationToken = default(CancellationToken));
    Task InsertAsync(TCollection document, CancellationToken cancellationToken = default(CancellationToken));
    Task<IEnumerable<TCollection>> CreateRangeAsync(IEnumerable<TCollection> documents, CancellationToken cancellationToken = default(CancellationToken));
    Task InsertRangeAsync(IEnumerable<TCollection> documents, CancellationToken cancellationToken = default(CancellationToken));
}
