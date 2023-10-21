using Example.API.Models;
using Gleeman.Repository.MongoDriver.Interfaces.Query;

namespace Example.API.Repositories.Queries;

public interface ICustomerQueryRepository:IMongoQueryAsyncRepository<Customer>
{
}
