namespace Gleeman.Repository.EFCore.Abstracts.Command;

public abstract class EFCommandRepository<TEntity, TDbContext> : 
    IEFCreateAsyncRepository<TEntity>,
    IEFCreateSyncRepository<TEntity>, 
    IEFUpdateAsyncRepository<TEntity>, 
    IEFUpdateSyncRepository<TEntity>,
    IEFDeleteAsyncRepository<TEntity>,
    IEFDeleteSyncRepository<TEntity>

where TEntity : class
where TDbContext : DbContext
{
    protected readonly TDbContext _dbContext;
    protected readonly DbSet<TEntity> _table;

    protected EFCommandRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
        _table = _dbContext.Set<TEntity>();
    }


    #region Async Creating

    public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _table.AddAsync(entity, cancellationToken);
        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _table.AddRangeAsync(entities, cancellationToken);
        return entities;
    }

    public virtual async Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _table.AddAsync(entity, cancellationToken);
    }

    public virtual async Task InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _table.AddRangeAsync(entities, cancellationToken);
    }

    #endregion

    #region Sync Creating

    public virtual TEntity Create(TEntity entity)
    {
        _table.Add(entity);
        return entity;
    }

    public virtual void Insert(TEntity entity) => _table.Add(entity);

    public virtual IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entities)
    {
        _table.AddRange(entities);
        return entities;
    }

    public virtual void InsertRange(IEnumerable<TEntity> entities) => _table.AddRange(entities);


    #endregion

    #region Async Updating

    public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _table.Update(entity), cancellationToken);
        return entity;
    }

    public virtual async Task EditAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _table.Update(entity), cancellationToken);
    }

    public virtual async Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _table.UpdateRange(entities), cancellationToken);
        return entities;
    }

    public virtual async Task EditRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _table.UpdateRange(entities), cancellationToken);
    }

    #endregion

    #region Sync Updating

    public virtual TEntity Update(TEntity entity)
    {
        _table.Update(entity);
        return entity;
    }

    public virtual void Edit(TEntity entity) => _table.Update(entity);


    public virtual IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
    {
        _table.UpdateRange(entities);
        return entities;

    }

    public virtual void EditRange(IEnumerable<TEntity> entities) => _table.UpdateRange(entities);

    #endregion

    #region Async Deleting

    public virtual async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _table.Remove(entity), cancellationToken);
        return entity;
    }

    public virtual async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _table.Remove(entity), cancellationToken);
    }

    public virtual async Task<IEnumerable<TEntity>> DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _table.RemoveRange(entities), cancellationToken);
        return entities;
    }

    public virtual async Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _table.RemoveRange(entities), cancellationToken);
    }


    #endregion

    #region Sync Deleting

    public virtual TEntity Delete(TEntity entity)
    {
        _table.Remove(entity);
        return entity;
    }

    public virtual void Remove(TEntity entity)
    {
        _table.Remove(entity);

    }

    public virtual IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entities)
    {
        _table.RemoveRange(entities);
        return entities;
    }

    public virtual void RemoveRange(IEnumerable<TEntity> entities)
    {
        _table.RemoveRange(entities);
    }

    #endregion

    #region Async Saving

    public async Task<int> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken)) => await _dbContext.SaveChangesAsync(cancellationToken);

    public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();


    #endregion

    #region Sync Saving

    public int Execute() => _dbContext.SaveChanges();

    public void Dispose() => _dbContext.Dispose();

    #endregion

}
