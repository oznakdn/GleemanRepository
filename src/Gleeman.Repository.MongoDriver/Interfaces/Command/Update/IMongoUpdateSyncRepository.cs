using MongoDB.Driver;

namespace Gleeman.Repository.MongoDriver.Interfaces.Command.Update;

public interface IMongoUpdateSyncRepository<TCollection>
    where TCollection : class
{
    TCollection Update(FilterDefinition<TCollection> filter, TCollection collection);
    void Edit(FilterDefinition<TCollection> filter, TCollection collection);
    void EditRange(FilterDefinition<TCollection> filter, UpdateDefinition<TCollection> update);

}
