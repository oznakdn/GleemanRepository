namespace Gleeman.Repository.MongoDriver.Interfaces.Command.Create;

public interface IMongoCreateSyncRepository<TCollection>
    where TCollection : class
{
    TCollection Create(TCollection document);
    void Insert(TCollection document);
    IEnumerable<TCollection> CreateRange(IEnumerable<TCollection> documents);
    void InsertRange(IEnumerable<TCollection> documents);
}
