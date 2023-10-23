using Microsoft.Extensions.DependencyInjection;

namespace Gleeman.Repository.Dapper.Configuration;

public static class ServiceConfiguration
{
    public static string ConnectionString { get; set; }
    public static IServiceCollection AddDapperRepository(this IServiceCollection services, Action<DapperOption> option)
    {
        DapperOption dapperOption = new();
        option.Invoke(dapperOption);
        ConnectionString = dapperOption.ConnectionString;
        return services;
    }
}
