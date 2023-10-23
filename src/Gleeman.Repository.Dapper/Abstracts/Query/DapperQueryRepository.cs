using Dapper;
using Gleeman.Repository.Dapper.Interfaces.Query;
using System.Data;

namespace Gleeman.Repository.Dapper.Abstracts.Query;

public class DapperQueryRepository<TEntity> :
    IDapperQueryAsyncRepository<TEntity>,
    IDapperQuerySyncRepository<TEntity>
    where TEntity : class
{

    protected DapperContext _context;
    public DapperQueryRepository()
    {
        _context = new();
    }

    public virtual async Task<IEnumerable<TEntity>> ReadAllAsync(string sql, Action<Pagination> pagination = null)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        var query = await connection.QueryAsync<TEntity>(sql, pagination);
        if (pagination != null)
        {
            Pagination page = new();
            pagination.Invoke(page);
            query = query.Skip((page.PageNumber - 1) * page.PageSize).Take(page.PageSize).ToList();
        }
        else
        {
            query = query.ToList();
        }
        return query;
    }


    public virtual async Task<TEntity> ReadFirstAsync(string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        var query = await connection.QueryAsync<TEntity>(sql);
        return query.First();
    }

    public virtual async Task<TEntity> ReadFirstOrDefaultAsync(string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        var query = await connection.QueryAsync<TEntity>(sql);
        return query.FirstOrDefault()!;
    }

    public virtual async Task<TEntity> ReadLastAsync(string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        var query = await connection.QueryAsync<TEntity>(sql);
        return query.Last();
    }

    public virtual async Task<TEntity> ReadLastOrDefaultAsync(string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        var query = await connection.QueryAsync<TEntity>(sql);
        return query.LastOrDefault()!;
    }

    
    public virtual async Task<TEntity> ReadSingleAsync(string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        var query = await connection.QueryAsync<TEntity>(sql);
        return query.Single();
    }


    public virtual async Task<TEntity> ReadSingleOrDefaultAsync(string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        var query = await connection.QueryAsync<TEntity>(sql);
        return query.SingleOrDefault()!;
    }

    public virtual IEnumerable<TEntity> ReadAll(string sql, Action<Pagination> pagination = null)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        var query = connection.Query<TEntity>(sql, pagination);
        if (pagination != null)
        {
            Pagination page = new();
            pagination.Invoke(page);
            query = query.Skip((page.PageNumber - 1) * page.PageSize).Take(page.PageSize).ToList();
        }
        else
        {
            query = query.ToList();
        }
        return query;
    }

    public virtual TEntity ReadLast(string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        var query = connection.Query<TEntity>(sql);
        return query.Last();
    }

    public virtual TEntity ReadSingle(string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        var query = connection.Query<TEntity>(sql);
        return query.Single();
    }

    public virtual TEntity ReadFirstOrDefault(string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        var query = connection.Query<TEntity>(sql);
        return query.FirstOrDefault()!;
    }

    public virtual TEntity ReadSingleOrDefault(string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        var query = connection.Query<TEntity>(sql);
        return query.SingleOrDefault()!;
    }

    public virtual TEntity ReadLastOrDefault(string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        var query = connection.Query<TEntity>(sql);
        return query.LastOrDefault()!;
    }

    public virtual TEntity ReadFirst(string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        var query = connection.Query<TEntity>(sql);
        return query.First();
    }


}
