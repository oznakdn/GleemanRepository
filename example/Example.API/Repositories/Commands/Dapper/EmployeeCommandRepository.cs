using Example.API.Models;
using Gleeman.Repository.Dapper.Abstracts.Command;

namespace Example.API.Repositories.Commands.Dapper;

public class EmployeeCommandRepository:DapperCommandRepository<Employee>,IEmployeeCommandRepository
{

}
