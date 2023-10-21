using System.Linq.Expressions;

namespace Gleeman.Repository.MongoDriver.Interfaces.Query;

public interface IMongoQuerySyncRepository<TCollection>
    where TCollection : class
{
    IEnumerable<TCollection> ReadAll(Expression<Func<TCollection, bool>> filter = null, Action<Pagination> pagination = null);
    TCollection ReadSingleOrDefault(Expression<Func<TCollection, bool>> filter);
    TCollection ReadFirstOrDefaut(Expression<Func<TCollection, bool>> filter);
    TCollection ReadSingle(Expression<Func<TCollection, bool>> filter);
    TCollection ReadFirst(Expression<Func<TCollection, bool>> filter);
}
