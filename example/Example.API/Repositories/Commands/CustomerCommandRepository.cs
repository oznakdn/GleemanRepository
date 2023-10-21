using Example.API.Models;
using Gleeman.Repository.MongoDriver;
using Gleeman.Repository.MongoDriver.Abstracts.Command;
using Microsoft.Extensions.Options;

namespace Example.API.Repositories.Commands;

public class CustomerCommandRepository : MongoCommandRepository<Customer>,ICustomerCommandRepository
{
    public CustomerCommandRepository(IOptions<MongoOption>? option) : base(option, nameof(Customer))
    {
    }

}
