using System.Linq.Expressions;

namespace Gleeman.Repository.MongoDriver.Interfaces.Query;

public interface IMongoQueryAsyncRepository<TCollection>
    where TCollection : class
{
    Task<IEnumerable<TCollection>> ReadAllAsync(CancellationToken cancellationToken = default(CancellationToken), 
        Expression<Func<TCollection, bool>> filter = null, 
        Action<Pagination> pagination = null);
    Task<TCollection> ReadSingleOrDefaultAsync(Expression<Func<TCollection, bool>> filter, 
        CancellationToken cancellationToken = default(CancellationToken));

    Task<TCollection> ReadFirstOrDefaultAsync(Expression<Func<TCollection, bool>> filter, 
        CancellationToken cancellationToken = default(CancellationToken));

    Task<TCollection> ReadSingleAsync(Expression<Func<TCollection, bool>> filter, 
        CancellationToken cancellationToken = default(CancellationToken));

    Task<TCollection> ReadFirstAsync(Expression<Func<TCollection, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken));

}
