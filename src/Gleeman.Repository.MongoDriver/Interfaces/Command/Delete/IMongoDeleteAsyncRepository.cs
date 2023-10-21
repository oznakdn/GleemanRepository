using MongoDB.Driver;

namespace Gleeman.Repository.MongoDriver.Interfaces.Command.Delete;

public interface IMongoDeleteAsyncRepository<TCollection>
    where TCollection : class
{
    Task DeleteAsync(FilterDefinition<TCollection> filter, CancellationToken cancellationToken = default(CancellationToken));
    Task DeleteRangeAsync(FilterDefinition<TCollection> filter, CancellationToken cancellationToken = default(CancellationToken));

}
