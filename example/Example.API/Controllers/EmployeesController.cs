using Dapper;
using Example.API.Models;
using Example.API.Repositories.Commands.Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Example.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeCommandRepository _command;

    public EmployeesController(IEmployeeCommandRepository command)
    {
        _command = command;
    }

    [HttpPost]
    public async Task<IActionResult>CreateEmployee(Employee employee)
    {
        string sql= "INSERT INTO Companies (CompanyName, CompanyAddress, Country,GlassdoorRating) VALUES (@Name, @Salary)";

        var parameters = new DynamicParameters();
        parameters.Add("Name", employee.Name, DbType.String);
        parameters.Add("Salary", employee.Salary, DbType.Decimal);
        var result = await _command.CreateAsync(employee,sql);
        return Created("", result);
    }
}
