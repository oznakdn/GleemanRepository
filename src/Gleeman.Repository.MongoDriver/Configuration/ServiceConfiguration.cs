using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gleeman.Repository.MongoDriver.Configuration;

public static class ServiceConfiguration
{
    public static string ConnectionString;
    public static string DatabaseName;
    public static IServiceCollection AddMongoRepository(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<MongoOption>(configuration.GetSection(nameof(MongoOption)));
        return services;
    }

    public static IServiceCollection AddMongoRepository(this IServiceCollection services, Action<MongoOption>option)
    {
        MongoOption mongoOption = new();
        option.Invoke(mongoOption);
        ConnectionString = mongoOption.ConnectionString;
        DatabaseName = mongoOption.DatabaseName;
        return services;
    }
}
