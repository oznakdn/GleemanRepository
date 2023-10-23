using Example.API.Models;
using Gleeman.Repository.Dapper.Interfaces.Command.Create;

namespace Example.API.Repositories.Commands.Dapper;

public interface IEmployeeCommandRepository:IDapperCreateAsyncRepository<Employee>
{
}
