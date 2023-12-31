namespace Gleeman.Repository.MongoDriver.Options;

public interface IMongoOptions
{
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}
