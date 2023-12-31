using Gleeman.Repository.MongoDriver.Context;
using Gleeman.Repository.MongoDriver.Interfaces.Command.Create;
using Gleeman.Repository.MongoDriver.Interfaces.Command.Delete;
using Gleeman.Repository.MongoDriver.Interfaces.Command.Update;
using Gleeman.Repository.MongoDriver.Options;
using MongoDB.Driver;

namespace Gleeman.Repository.MongoDriver.Abstracts.Command;

public abstract class MongoCommandRepository<TCollection> : MongoContext<TCollection>,
    IMongoCreateAsyncRepository<TCollection>,
    IMongoCreateSyncRepository<TCollection>,
    IMongoDeleteAsyncRepository<TCollection>,
    IMongoDeleteSyncRepository<TCollection>,
    IMongoUpdateAsyncRepository<TCollection>,
    IMongoUpdateSyncRepository<TCollection>
    where TCollection : class
{
    protected MongoCommandRepository(IMongoOptions option) : base(option)
    {
    }




    #region Create

    public virtual async Task<TCollection> CreateAsync(TCollection document, CancellationToken cancellationToken = default)
    {
        await Collection.InsertOneAsync(document);
        return document;
    }


    public virtual async Task<IEnumerable<TCollection>> CreateRangeAsync(IEnumerable<TCollection> documents, CancellationToken cancellationToken = default)
    {
        await Collection.InsertManyAsync(documents);
        return documents;
    }

    public virtual async Task InsertAsync(TCollection document, CancellationToken cancellationToken = default)
    {
        await Collection.InsertOneAsync(document);
    }


    public virtual async Task InsertRangeAsync(IEnumerable<TCollection> documents, CancellationToken cancellationToken = default)
    {
        await Collection.InsertManyAsync(documents);
    }


    public virtual void Insert(TCollection document)
    {
        Collection.InsertOne(document);
    }

    public virtual TCollection Create(TCollection document)
    {
        Collection.InsertOne(document);
        return document;
    }

    public virtual void InsertRange(IEnumerable<TCollection> documents)
    {
        Collection.InsertMany(documents);
    }

    public virtual IEnumerable<TCollection> CreateRange(IEnumerable<TCollection> documents)
    {
        Collection.InsertMany(documents);
        return documents;
    }


    #endregion

    #region Delete

    public virtual async Task DeleteAsync(FilterDefinition<TCollection> filter, CancellationToken cancellationToken = default)
    {
        await Collection.DeleteOneAsync(filter);
    }


    public virtual async Task DeleteRangeAsync(FilterDefinition<TCollection> filter, CancellationToken cancellationToken = default)
    {
        await Collection.DeleteManyAsync(filter);
    }

    public virtual void Delete(FilterDefinition<TCollection> filter)
    {
        Collection.DeleteOne(filter);
    }

    public virtual void DeleteRange(FilterDefinition<TCollection> filter)
    {
        Collection.DeleteMany(filter);
    }

    #endregion

    #region Update

    public virtual async Task<TCollection> UpdateAsync(FilterDefinition<TCollection>filter,TCollection collection, CancellationToken cancellationToken = default)
    {
        await Collection.ReplaceOneAsync(filter,collection);
        return collection;
    }

    public virtual async Task EditAsync(FilterDefinition<TCollection> filter,TCollection collection, CancellationToken cancellationToken = default)
    {
        await Collection.ReplaceOneAsync(filter, collection);
    }

    public virtual async Task EditRangeAsync(FilterDefinition<TCollection> filter,UpdateDefinition<TCollection>update, CancellationToken cancellationToken = default)
    {
        await Collection.UpdateManyAsync(filter,update);
        
    }

    public virtual TCollection Update(FilterDefinition<TCollection> filter, TCollection collection)
    {
        Collection.ReplaceOne(filter, collection);
        return collection;
    }

    public virtual void Edit(FilterDefinition<TCollection> filter, TCollection collection)
    {
        Collection.ReplaceOne(filter, collection);
    }

    public virtual void EditRange(FilterDefinition<TCollection> filter, UpdateDefinition<TCollection> update)
    {
        Collection.UpdateMany(filter, update);
    }

    #endregion


}
