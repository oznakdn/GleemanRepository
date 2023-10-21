using Gleeman.Repository.MongoDriver.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Gleeman.Repository.MongoDriver;

public abstract class MongoContext<TCollection>
where TCollection : class
{
    protected readonly IMongoCollection<TCollection> _collection;
    private readonly IMongoClient _client;
    private readonly MongoOption _option;
    protected string Collection { get; set; }

    public MongoContext(IOptions<MongoOption>? option, string collection)
    {
        _option = option!.Value;
        Collection = collection;
        IMongoDatabase database;
        if (!string.IsNullOrEmpty(_option.ConnectionString) && 
            !string.IsNullOrEmpty(_option.DatabaseName) && 
            !string.IsNullOrEmpty(collection))
        {
            _client = new MongoClient(_option.ConnectionString);
            database = _client.GetDatabase(_option.DatabaseName);
            _collection = database.GetCollection<TCollection>(collection);
        }
        else if (!string.IsNullOrEmpty(ServiceConfiguration.ConnectionString) && 
            !string.IsNullOrEmpty(ServiceConfiguration.DatabaseName) && 
            !string.IsNullOrEmpty(collection))
        {
            _client = new MongoClient(ServiceConfiguration.ConnectionString);
            database = _client.GetDatabase(ServiceConfiguration.DatabaseName);
            _collection = database.GetCollection<TCollection>(collection);
        }
        else
        {
            throw new ArgumentNullException(nameof(MongoOption));
        }
    }
}
