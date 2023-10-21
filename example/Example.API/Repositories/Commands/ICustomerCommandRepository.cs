using Example.API.Models;
using Gleeman.Repository.MongoDriver.Interfaces.Command.Create;

namespace Example.API.Repositories.Commands;

public interface ICustomerCommandRepository:IMongoCreateAsyncRepository<Customer>
{
}
