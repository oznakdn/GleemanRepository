using Gleeman.Repository.MongoDriver.Options;
using MongoDB.Driver;

namespace Gleeman.Repository.MongoDriver.Context;

public abstract class MongoContext<TCollection> : IMongoContext<TCollection>
where TCollection : class
{

    public IMongoCollection<TCollection> Collection { get; }
    public IMongoClient MongoClient { get; }


    public MongoContext(IMongoOptions option)
    {

        MongoClient = new MongoClient(option.ConnectionString);
        var database = MongoClient.GetDatabase(option.DatabaseName);
        Collection = database.GetCollection<TCollection>(typeof(TCollection).Name + "s");
    }

}
