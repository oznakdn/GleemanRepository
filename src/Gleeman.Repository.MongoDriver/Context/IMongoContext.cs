using MongoDB.Driver;

namespace Gleeman.Repository.MongoDriver.Context;

public interface IMongoContext<TCollection>
{
    IMongoCollection<TCollection> Collection { get; }
    IMongoClient MongoClient { get; }
}
