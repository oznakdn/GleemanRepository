using Example.API.Models;
using Example.API.Repositories.Commands;
using Example.API.Repositories.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerQueryRepository _query;
    private readonly ICustomerCommandRepository _command;

    public CustomersController(ICustomerQueryRepository query, ICustomerCommandRepository command)
    {
        _query = query;
        _command = command;
    }

    [HttpGet]
    public async Task<IActionResult>GetCustomers()
    {
        var result = await _query.ReadAllAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult>CreateCustomer(Customer customer)
    {
        var result = await _command.CreateAsync(customer);
        return Ok(result);
    }
}
