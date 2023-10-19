namespace Gleeman.Repository.EFCore.Abstracts.Query;

public abstract class EFQueryRepository<TEntity, TDbContext> : IEFQueryAsyncRepository<TEntity>, IEFQuerySyncRepository<TEntity>
where TEntity : class
where TDbContext : DbContext
{
    protected readonly TDbContext _dbContext;
    protected readonly DbSet<TEntity> _table;

    protected EFQueryRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
        _table = _dbContext.Set<TEntity>();
    }

    #region Async Reading

    public virtual async Task<IQueryable<TEntity>> QueryAsync(bool noTracking,
        Action<Pagination> pagination = null,
        Expression<Func<TEntity, bool>> filter = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _table;

        if (pagination is not null)
        {
            Pagination page = new();
            pagination?.Invoke(page);

            query = query.Skip((page.PageNumber - 1) * page.PageSize)
             .Take(page.PageSize);
        }

        query = filter is null ? query : query.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await Task.Run(() => query.AsQueryable(), cancellationToken);
    }

    public virtual async Task<IEnumerable<TEntity>> ReadAllAsync(bool noTracking,
        Action<Pagination> pagination = null,
        Expression<Func<TEntity, bool>> filter = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _table;

        if (pagination is not null)
        {
            Pagination page = new();
            pagination?.Invoke(page);

            query = query.Skip((page.PageNumber - 1) * page.PageSize)
             .Take(page.PageSize);
        }
        query = filter is null ? query : query.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await query.ToListAsync(cancellationToken);
    }

    public virtual async Task<TEntity> ReadSingleOrDefaultAsync(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await query.SingleOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<TEntity> ReadFirstOrDefaultAsync(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<TEntity> ReadLastOrDefaultAsync(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await query.LastOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<TEntity> ReadFirstAsync(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await query.FirstAsync(cancellationToken);
    }

    public virtual async Task<TEntity> ReadLastAsync(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await query.LastAsync(cancellationToken);
    }

    public virtual async Task<TEntity> ReadSingleAsync(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await query.SingleAsync(cancellationToken);
    }

    public virtual async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default) =>
        await _table.AnyAsync(filter, cancellationToken);

    #endregion

    #region Sync Reading

    public virtual IQueryable<TEntity> Query(bool noTracking,
        Action<Pagination> pagination = null,
        Expression<Func<TEntity, bool>> filter = null,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _table.AsQueryable();
        if (pagination is not null)
        {
            Pagination page = new();
            pagination?.Invoke(page);

            query = query.Skip((page.PageNumber - 1) * page.PageSize)
             .Take(page.PageSize);
        }

        query = filter is not null ? query.Where(filter) : query;

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return query;
    }

    public virtual IEnumerable<TEntity> ReadAll(bool noTracking,
        Action<Pagination> pagination = null,
        Expression<Func<TEntity, bool>> filter = null,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _table.AsQueryable();
        if (pagination is not null)
        {
            Pagination page = new();
            pagination?.Invoke(page);

            query = query.Skip((page.PageNumber - 1) * page.PageSize)
             .Take(page.PageSize);
        }

        query = filter is not null ? query.Where(filter) : query;
        
        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return query.ToList();
    }

    public virtual TEntity ReadSingleOrDefault(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return query.SingleOrDefault();
    }

    public virtual TEntity ReadFirstOrDefault(bool noTracking, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return query.FirstOrDefault();
    }

    public virtual TEntity ReadLastOrDefault(bool noTracking, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return query.LastOrDefault();
    }

    public virtual TEntity ReadFirst(bool noTracking, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return query.First();
    }

    public virtual TEntity ReadLast(bool noTracking, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return query.Last();
    }

    public virtual TEntity ReadSingle(bool noTracking, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return query.Single();
    }

    public virtual bool Exist(Expression<Func<TEntity, bool>> filter) => _table.Any(filter);


    #endregion



}
