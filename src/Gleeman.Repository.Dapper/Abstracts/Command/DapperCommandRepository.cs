using Dapper;
using Gleeman.Repository.Dapper.Interfaces.Command.Create;
using Gleeman.Repository.Dapper.Interfaces.Command.Delete;
using Gleeman.Repository.Dapper.Interfaces.Command.Update;
using System.Data;

namespace Gleeman.Repository.Dapper.Abstracts.Command;

public class DapperCommandRepository<TEntity>
    : IDapperCreateAsyncRepository<TEntity>,
    IDapperCreateSyncRepository<TEntity>,
    IDapperUpdateAsyncRepository<TEntity>,
    IDapperUpdateSyncRepository<TEntity>,
    IDapperDeleteAsyncRepository<TEntity>,
    IDapperDeleteSyncRepository<TEntity>
    where TEntity : class
{
    protected DapperContext _context;
    public DapperCommandRepository()
    {
        _context = new();
    }


    #region Create

    public virtual async Task<TEntity> CreateAsync(TEntity parameter, string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        await connection.ExecuteAsync(sql, parameter);
        return parameter;
    }

    public virtual async Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> parameters, string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        await connection.ExecuteAsync(sql, parameters);
        return parameters;
    }



    public virtual async Task InsertAsync(TEntity parameter, string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        await connection.ExecuteAsync(sql, parameter);
    }



    public virtual async Task InsertRangeAsync(IEnumerable<TEntity> parameters, string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        await connection.ExecuteAsync(sql, parameters);
    }

    public virtual void Insert(TEntity parameter, string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        connection.Execute(sql, parameter);
    }

    public virtual IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> parameters, string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        connection.Execute(sql, parameters);
        return parameters;
    }

    public virtual void InsertRange(IEnumerable<TEntity> parameters, string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        connection.Execute(sql, parameters);
    }

    public virtual TEntity Create(TEntity parameter, string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        connection.Execute(sql, parameter);
        return parameter;
    }

    #endregion


    #region Update

    public virtual async Task<TEntity> UpdateAsync(TEntity parameter, string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        await connection.ExecuteAsync(sql, parameter);
        return parameter;
    }

    public virtual async Task EditAsync(TEntity parameter, string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        await connection.ExecuteAsync(sql, parameter);
    }

    public virtual async Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> parameters, string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        await connection.ExecuteAsync(sql, parameters);
        return parameters;
    }

    public virtual async Task EditRangeAsync(IEnumerable<TEntity> parameters, string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        await connection.ExecuteAsync(sql, parameters);
    }

    public virtual TEntity Update(TEntity parameter, string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        connection.Execute(sql, parameter);
        return parameter;
    }

    public virtual void Edit(TEntity parameter, string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        connection.Execute(sql, parameter);
    }

    public virtual IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> parameters, string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        connection.Execute(sql, parameters);
        return parameters;
    }

    public virtual void EditRange(IEnumerable<TEntity> parameters, string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        connection.Execute(sql, parameters);
    }

    #endregion


    #region Delete

    public virtual async Task RemoveAsync(string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        await connection.ExecuteAsync(sql);
    }

    public virtual async Task RemoveRangeAsync(string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        await connection.ExecuteAsync(sql);
    }

    public virtual void Remove(string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        connection.Execute(sql);
    }

    public virtual void RemoveRange(string sql)
    {
        using var connection = _context.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        connection.Execute(sql);
    }



    #endregion


}
