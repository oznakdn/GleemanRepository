using Gleeman.Repository.Dapper.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Gleeman.Repository.Dapper;

public class DapperContext
{

    private readonly string _connectionString;
    public DapperContext()
    {

        if (!string.IsNullOrEmpty(ServiceConfiguration.ConnectionString))
            _connectionString = ServiceConfiguration.ConnectionString;
        else throw new ArgumentNullException(nameof(_connectionString));
    }
    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
