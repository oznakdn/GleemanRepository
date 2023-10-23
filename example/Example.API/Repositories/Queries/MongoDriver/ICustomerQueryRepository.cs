using Example.API.Models;
using Gleeman.Repository.MongoDriver.Interfaces.Query;

namespace Example.API.Repositories.Queries.MongoDriver;

public interface ICustomerQueryRepository : IMongoQueryAsyncRepository<Customer>
{
}
