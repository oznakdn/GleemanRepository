using Gleeman.Repository.MongoDriver.Interfaces.Query;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Gleeman.Repository.MongoDriver.Abstracts.Query;

public abstract class MongoQueryRepository<TCollection> : MongoContext<TCollection>,
    IMongoQueryAsyncRepository<TCollection>,
    IMongoQuerySyncRepository<TCollection>
    where TCollection : class
{
    
    protected MongoQueryRepository(IOptions<MongoOption>? option,string collection) : base(option, collection)
    {
        Collection = collection;
    }

    public virtual async Task<IEnumerable<TCollection>> ReadAllAsync(CancellationToken cancellationToken = default, Expression<Func<TCollection, bool>> filter = null,
        Action<Pagination> pagination = null)
    {
        Pagination page = new();
        pagination?.Invoke(page);

        if (pagination != null)
        {
            return await _collection.Find(filter == null ? x => true : filter).ToListAsync();
        }

        return await _collection.Find(filter == null ? x => true : filter).Skip((page.PageNumber - 1) * page.PageSize).Limit(page.PageSize).ToListAsync(cancellationToken);
    }

    public virtual async Task<TCollection> ReadFirstOrDefaultAsync(Expression<Func<TCollection, bool>> filter, CancellationToken cancellationToken = default)
    {
        return await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken); ;
    }

    public virtual async Task<TCollection> ReadSingleOrDefaultAsync(Expression<Func<TCollection, bool>> filter, CancellationToken cancellationToken = default)
    {
        return await _collection.Find(filter).SingleOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<TCollection> ReadSingleAsync(Expression<Func<TCollection, bool>> filter, CancellationToken cancellationToken = default)
    {
        return await _collection.Find(filter).SingleAsync(cancellationToken);
    }

    public virtual async Task<TCollection> ReadFirstAsync(Expression<Func<TCollection, bool>> filter, CancellationToken cancellationToken = default)
    {
        return await _collection.Find(filter).FirstAsync(cancellationToken);
    }

    public virtual IEnumerable<TCollection> ReadAll(Expression<Func<TCollection, bool>> filter = null, Action<Pagination> pagination = null)
    {
        Pagination page = new();
        pagination?.Invoke(page);

        if (pagination != null)
        {
            return _collection.Find(filter == null ? x => true : filter).ToList();
        }

        return _collection.Find(filter == null ? x => true : filter).Skip((page.PageNumber - 1) * page.PageSize).Limit(page.PageSize).ToList();
    }

    public virtual TCollection ReadSingleOrDefault(Expression<Func<TCollection, bool>> filter)
    {
        return _collection.Find(filter).SingleOrDefault();
    }

    public virtual TCollection ReadFirstOrDefaut(Expression<Func<TCollection, bool>> filter)
    {
        return _collection.Find(filter).FirstOrDefault();
    }

    public virtual TCollection ReadSingle(Expression<Func<TCollection, bool>> filter)
    {
        return _collection.Find(filter).Single();
    }

    public virtual TCollection ReadFirst(Expression<Func<TCollection, bool>> filter)
    {
        return _collection.Find(filter).First();
    }

}
