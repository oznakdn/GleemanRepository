using Example.API.Models;
using Gleeman.Repository.MongoDriver;
using Gleeman.Repository.MongoDriver.Abstracts.Query;
using Microsoft.Extensions.Options;

namespace Example.API.Repositories.Queries;

public class CustomerQueryRepository : MongoQueryRepository<Customer>, ICustomerQueryRepository
{
    public CustomerQueryRepository(IOptions<MongoOption>? option) : base(option, nameof(Customer))
    {

    }

}
