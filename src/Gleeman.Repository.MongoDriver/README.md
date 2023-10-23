# Gleeman.Repository.MongoDriver

### Command Repositories
#### Create
```csharp
public interface IMongoCreateAsyncRepository<TCollection>
    where TCollection : class
{
    Task<TCollection> CreateAsync(TCollection document, CancellationToken cancellationToken = default(CancellationToken));
    Task InsertAsync(TCollection document, CancellationToken cancellationToken = default(CancellationToken));
    Task<IEnumerable<TCollection>> CreateRangeAsync(IEnumerable<TCollection> documents, CancellationToken cancellationToken = default(CancellationToken));
    Task InsertRangeAsync(IEnumerable<TCollection> documents, CancellationToken cancellationToken = default(CancellationToken));
}
```
```csharp
public interface IMongoCreateSyncRepository<TCollection>
    where TCollection : class
{
    TCollection Create(TCollection document);
    void Insert(TCollection document);
    IEnumerable<TCollection> CreateRange(IEnumerable<TCollection> documents);
    void InsertRange(IEnumerable<TCollection> documents);
}
```
#### Delete
```csharp
public interface IMongoDeleteAsyncRepository<TCollection>
    where TCollection : class
{
    Task DeleteAsync(FilterDefinition<TCollection> filter, CancellationToken cancellationToken = default(CancellationToken));
    Task DeleteRangeAsync(FilterDefinition<TCollection> filter, CancellationToken cancellationToken = default(CancellationToken));
}
```
```csharp
public interface IMongoDeleteSyncRepository<TCollection>
    where TCollection : class
{

    void Delete(FilterDefinition<TCollection> filter);
    void DeleteRange(FilterDefinition<TCollection> filter);
}
```
#### Update
```csharp
public interface IMongoUpdateAsyncRepository<TCollection>
    where TCollection : class
{
    Task<TCollection> UpdateAsync(FilterDefinition<TCollection> filter, TCollection collection, CancellationToken cancellationToken = default);
    Task EditAsync(FilterDefinition<TCollection> filter, TCollection collection, CancellationToken cancellationToken = default);
    Task EditRangeAsync(FilterDefinition<TCollection> filter, UpdateDefinition<TCollection> update, CancellationToken cancellationToken = default);
}
```
```csharp
public interface IMongoUpdateSyncRepository<TCollection>
    where TCollection : class
{
    TCollection Update(FilterDefinition<TCollection> filter, TCollection collection);
    void Edit(FilterDefinition<TCollection> filter, TCollection collection);
    void EditRange(FilterDefinition<TCollection> filter, UpdateDefinition<TCollection> update);
}
```

### Query Repositories
```csharp
public interface IMongoQueryAsyncRepository<TCollection>
    where TCollection : class
{
    Task<IEnumerable<TCollection>> ReadAllAsync(CancellationToken cancellationToken = default(CancellationToken), 
        Expression<Func<TCollection, bool>> filter = null, 
        Action<Pagination> pagination = null);
    Task<TCollection> ReadSingleOrDefaultAsync(Expression<Func<TCollection, bool>> filter, 
        CancellationToken cancellationToken = default(CancellationToken));

    Task<TCollection> ReadFirstOrDefaultAsync(Expression<Func<TCollection, bool>> filter, 
        CancellationToken cancellationToken = default(CancellationToken));

    Task<TCollection> ReadSingleAsync(Expression<Func<TCollection, bool>> filter, 
        CancellationToken cancellationToken = default(CancellationToken));

    Task<TCollection> ReadFirstAsync(Expression<Func<TCollection, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken));
}
```
```csharp
public interface IMongoQuerySyncRepository<TCollection>
    where TCollection : class
{
    IEnumerable<TCollection> ReadAll(Expression<Func<TCollection, bool>> filter = null, Action<Pagination> pagination = null);
    TCollection ReadSingleOrDefault(Expression<Func<TCollection, bool>> filter);
    TCollection ReadFirstOrDefaut(Expression<Func<TCollection, bool>> filter);
    TCollection ReadSingle(Expression<Func<TCollection, bool>> filter);
    TCollection ReadFirst(Expression<Func<TCollection, bool>> filter);
}
```

## EXAMPLE
#### Program.cs
```csharp
using Gleeman.Repository.MongoDriver.Configuration;
```
```csharp
builder.Services.AddMongoRepository(option =>
{
    option.DatabaseName = "TestDB";
    option.ConnectionString = "mongodb://localhost:27017";
});
```
### OR
#### appsettings.json
```json
 "MongoOption": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "Test"
  }
```
#### Program.cs
```csharp
builder.Services.AddMongoRepository(builder.Configuration);
```

```csharp
public interface ICustomerQueryRepository:IMongoQueryAsyncRepository<Customer>
{
}


public class CustomerQueryRepository : MongoQueryRepository<Customer>, ICustomerQueryRepository
{
    public CustomerQueryRepository(IOptions<MongoOption>? option) : base(option, nameof(Customer))
    {

    }
}

public interface ICustomerCommandRepository:IMongoCreateAsyncRepository<Customer>
{
}

public class CustomerCommandRepository : MongoCommandRepository<Customer>,ICustomerCommandRepository
{
    public CustomerCommandRepository(IOptions<MongoOption>? option) : base(option, nameof(Customer))
    {
    }
}
```

```csharp
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
```


