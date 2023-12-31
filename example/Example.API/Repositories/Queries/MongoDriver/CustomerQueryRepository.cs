using Example.API.Models;
using Gleeman.Repository.MongoDriver.Abstracts.Query;
using Gleeman.Repository.MongoDriver.Options;

namespace Example.API.Repositories.Queries.MongoDriver;

public class CustomerQueryRepository : MongoQueryRepository<Customer>, ICustomerQueryRepository
{
    public CustomerQueryRepository(IMongoOptions option) : base(option)
    {
    }
}
