using MongoDB.Driver;

namespace Gleeman.Repository.MongoDriver.Interfaces.Command.Update;

public interface IMongoUpdateAsyncRepository<TCollection>
    where TCollection : class
{
    Task<TCollection> UpdateAsync(FilterDefinition<TCollection> filter, TCollection collection, CancellationToken cancellationToken = default);
    Task EditAsync(FilterDefinition<TCollection> filter, TCollection collection, CancellationToken cancellationToken = default);
    Task EditRangeAsync(FilterDefinition<TCollection> filter, UpdateDefinition<TCollection> update, CancellationToken cancellationToken = default);

}
