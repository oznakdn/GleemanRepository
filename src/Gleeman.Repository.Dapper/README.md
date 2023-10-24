# Gleeman.Repository.Dapper

### Command Repositories
#### Create
```csharp
public interface IDapperCreateAsyncRepository<TEntity>
    where TEntity : class
{
    Task<TEntity> CreateAsync(TEntity parameter, string sql);
    Task InsertAsync(TEntity parameter, string sql);
    Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> parameters, string sql);
    Task InsertRangeAsync(IEnumerable<TEntity> parameters, string sql);
}
```
```csharp
public interface IDapperCreateSyncRepository<TEntity>
{
    TEntity Create(TEntity parameter, string sql);
    void Insert(TEntity parameter, string sql);
    IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> parameters, string sql);
    void InsertRange(IEnumerable<TEntity> parameters, string sql);
}
```
#### Delete
```csharp
public interface IDapperDeleteAsyncRepository<TEntity>
    where TEntity : class
{
    Task RemoveAsync(string sql);
    Task RemoveRangeAsync(string sql);
}
```
```csharp
public interface IDapperDeleteSyncRepository<TEntity>
    where TEntity : class
{
    void Remove(string sql);
    void RemoveRange(string sql);
}
```
#### Update
```csharp
public interface IDapperUpdateAsyncRepository<TEntity>
    where TEntity : class
{
    Task<TEntity> UpdateAsync(TEntity parameter, string sql);
    Task EditAsync(TEntity parameter, string sql);
    Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> parameters, string sql);
    Task EditRangeAsync(IEnumerable<TEntity> parameters, string sql);
}
```
```csharp
public interface IDapperUpdateSyncRepository<TEntity>
        where TEntity : class
    {
        TEntity Update(TEntity parameter, string sql);
        void Edit(TEntity parameter, string sql);
        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> parameters, string sql);
        void EditRange(IEnumerable<TEntity> parameters, string sql);
    }
```
### Query Repositories
```csharp
public interface IDapperQueryAsyncRepository<TEntity>
    where TEntity : class
{

    Task<IEnumerable<TEntity>> ReadAllAsync(string sql, Action<Pagination> pagination = null);

    Task<TEntity> ReadSingleOrDefaultAsync(string sql);

    Task<TEntity> ReadFirstOrDefaultAsync(string sql);

    Task<TEntity> ReadLastOrDefaultAsync(string sql);

    Task<TEntity> ReadFirstAsync(string sql);

    Task<TEntity> ReadLastAsync(string sql);

    Task<TEntity> ReadSingleAsync(string sql);
}
```
```csharp
public interface IDapperQuerySyncRepository<TEntity>
    where TEntity : class
{
    IEnumerable<TEntity> ReadAll(string sql, Action<Pagination> pagination = null);

    TEntity ReadSingleOrDefault(string sql);

    TEntity ReadFirstOrDefault(string sql);

    TEntity ReadLastOrDefault(string sql);

    TEntity ReadFirst(string sql);

    TEntity ReadLast(string sql);

    TEntity ReadSingle(string sql);
}
```

## EXAMPLE
#### Program.cs
```csharp
using Gleeman.Repository.Dapper.Configuration;
```
```csharp
builder.Services.AddDapperRepository(option =>
{
    option.ConnectionString = "Server=(localdb)/MSSQLLocalDB;Database=EmployeeDB;Trusted_Connection=True;";
});
```

```csharp
public interface IEmployeeCommandRepository:IDapperCreateAsyncRepository<Employee>
{
}

public class EmployeeCommandRepository:DapperCommandRepository<Employee>,IEmployeeCommandRepository
{

}
```

```csharp

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
        string sql= "INSERT INTO Employees (Name, Salary) VALUES (@Name, @Salary)";

        var parameters = new DynamicParameters();
        parameters.Add("Name", employee.Name, DbType.String);
        parameters.Add("Salary", employee.Salary, DbType.Decimal);
        var result = await _command.CreateAsync(employee,sql);
        return Created("", result);
    }
}
```
