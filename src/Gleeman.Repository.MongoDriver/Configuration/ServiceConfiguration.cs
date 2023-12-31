using Gleeman.Repository.MongoDriver.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Gleeman.Repository.MongoDriver.Configuration;

public static class ServiceConfiguration
{
    public static IServiceCollection AddMongoRepository(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<MongoOptions>(configuration.GetSection(nameof(MongoOptions)));
        services.AddScoped<IMongoOptions>(sp => sp.GetRequiredService<IOptions<MongoOptions>>().Value);
        return services;
    }

}
