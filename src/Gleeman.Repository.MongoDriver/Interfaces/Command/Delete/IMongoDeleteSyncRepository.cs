using MongoDB.Driver;

namespace Gleeman.Repository.MongoDriver.Interfaces.Command.Delete;

public interface IMongoDeleteSyncRepository<TCollection>
    where TCollection : class
{

    void Delete(FilterDefinition<TCollection> filter);
    void DeleteRange(FilterDefinition<TCollection> filter);

}
