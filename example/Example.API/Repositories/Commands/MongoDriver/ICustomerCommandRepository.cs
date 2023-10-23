using Example.API.Models;
using Gleeman.Repository.MongoDriver.Interfaces.Command.Create;

namespace Example.API.Repositories.Commands.MongoDriver;

public interface ICustomerCommandRepository : IMongoCreateAsyncRepository<Customer>
{
}
