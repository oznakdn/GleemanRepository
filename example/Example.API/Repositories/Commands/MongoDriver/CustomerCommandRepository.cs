using Example.API.Models;
using Gleeman.Repository.MongoDriver.Abstracts.Command;
using Gleeman.Repository.MongoDriver.Options;

namespace Example.API.Repositories.Commands.MongoDriver;

public class CustomerCommandRepository : MongoCommandRepository<Customer>, ICustomerCommandRepository
{
    public CustomerCommandRepository(IMongoOptions option) : base(option)
    {
    }
}
