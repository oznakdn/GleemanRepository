# GleemanRepository

### Command Repositories
#### Create
```csharp
public interface IEFCreateAsyncRepository<TEntity> : IEFAsyncRepository
where TEntity : class
{
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
    Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
    Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
    Task InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
}
```
```csharp
public interface IEFCreateSyncRepository<TEntity> : IEFSyncRepository
where TEntity : class
{
    TEntity Create(TEntity entity);
    void Insert(TEntity entity);
    IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entities);
    void InsertRange(IEnumerable<TEntity> entities);
}
```
#### Delete
```csharp
public interface IEFDeleteAsyncRepository<TEntity>:IEFAsyncRepository
where TEntity : class
{
    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
    Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
    Task<IEnumerable<TEntity>> DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
    Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
}
```
```csharp
public interface IEFDeleteSyncRepository<TEntity>:IEFSyncRepository
 where TEntity : class
{
    TEntity Delete(TEntity entity);
    void Remove(TEntity entity);
    IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entities);
    void RemoveRange(IEnumerable<TEntity> entities);
}
```
#### Update
```csharp
public interface IEFUpdateAsyncRepository<TEntity>:IEFAsyncRepository
where TEntity : class
{
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task EditAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    Task EditRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
}
```
```csharp
public interface IEFUpdateSyncRepository<TEntity>:IEFSyncRepository
where TEntity : class
{
    TEntity Update(TEntity entity);
    void Edit(TEntity entity);
    IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);
    void EditRange(IEnumerable<TEntity> entities);
}
```

### Query Repositories
```csharp
public interface IEFQueryAsyncRepository<TEntity>
where TEntity : class
{
    Task<IQueryable<TEntity>> QueryAsync(bool noTracking,
        Action<Pagination> pagination = null,
        Expression<Func<TEntity, bool>> filter = null,
        CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<TEntity, object>>[] includeProperties);

    Task<IEnumerable<TEntity>> ReadAllAsync(bool noTracking,
        Action<Pagination> pagination = null,
        Expression<Func<TEntity, bool>> filter = null,
        CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<TEntity, object>>[] includeProperties);

    Task<TEntity> ReadSingleOrDefaultAsync(bool noTracking,Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<TEntity, object>>[] includeProperties);

    Task<TEntity> ReadFirstOrDefaultAsync(bool noTracking,Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<TEntity, object>>[] includeProperties);

    Task<TEntity> ReadLastOrDefaultAsync(bool noTracking, Expression<Func<TEntity, bool>> filter,
       CancellationToken cancellationToken = default(CancellationToken),
       params Expression<Func<TEntity, object>>[] includeProperties);

    Task<TEntity> ReadFirstAsync(bool noTracking,Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<TEntity, object>>[] includeProperties);

    Task<TEntity> ReadLastAsync(bool noTracking,Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<TEntity, object>>[] includeProperties);

    Task<TEntity> ReadSingleAsync(bool noTracking,Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<TEntity, object>>[] includeProperties);

    Task<bool> ExistAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default(CancellationToken));
}
```
```csharp
public interface IEFQuerySyncRepository<TEntity>
where TEntity : class
{
    IQueryable<TEntity> Query(bool noTracking,
        Action<Pagination> pagination = null,
        Expression<Func<TEntity, bool>> filter = null,
        params Expression<Func<TEntity, object>>[] includeProperties);

    IEnumerable<TEntity> ReadAll(bool noTracking,
         Action<Pagination> pagination = null,
        Expression<Func<TEntity, bool>> filter = null,
        params Expression<Func<TEntity, object>>[] includeProperties);

    TEntity ReadSingleOrDefault(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] includeProperties);

    TEntity ReadFirstOrDefault(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] includeProperties);

    TEntity ReadLastOrDefault(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
       params Expression<Func<TEntity, object>>[] includeProperties);

    TEntity ReadFirst(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] includeProperties);

    TEntity ReadLast(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] includeProperties);

    TEntity ReadSingle(bool noTracking,
        Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] includeProperties);

    bool Exist(Expression<Func<TEntity, bool>> filter);
}
```

## EXAMPLE

```csharp
public interface IProductQueryRepository:IEFQueryAsyncRepository<Product>,IEFQuerySyncRepository<Product>
{
}

public interface IProductCommandRepository : 
IEFCreateAsyncRepository<Product>, 
IEFCreateSyncRepository<Product>, 
IEFUpdateAsyncRepository<Product>, 
IEFUpdateSyncRepository<Product>, 
IEFDeleteAsyncRepository<Product>,
IEFDeleteSyncRepository<Product>
{
    
}

public class ProductQueryRepository : EFQueryRepository<Product, AppDbContext>, IProductQueryRepository
{
    public ProductQueryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}

public class ProductCommandRepository : EFCommandRepository<Product, AppDbContext>,IProductCommandRepository
{
    public ProductCommandRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
```

```csharp
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductCommandRepository _command;
        private readonly IProductQueryRepository _query;

        public ProductsController(IProductCommandRepository command, IProductQueryRepository query)
        {
            _command = command;
            _query = query;
        }


        // Async Queries
        
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await _query.ReadAllAsync(noTracking: true);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsWithCategoryAsync()
        {
            var result = await _query.ReadAllAsync(noTracking: true, includeProperties: x => x.Category);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsWithPaginationAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var result = await _query.ReadAllAsync(noTracking: true, pagination: pagination =>
            {

                pagination.MaxPageSize = 50;
                pagination.PageNumber = pageNumber;
                pagination.PageSize = pageSize;
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var result = await _query.ReadSingleOrDefaultAsync(true, x => x.Id == id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductWithCategoryAsync(int id)
        {
            var result = await _query.ReadSingleOrDefaultAsync(true, x => x.Id == id, includeProperties: x => x.Category);
            return Ok(result);
        }
        

        // Sync Queries

        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = _query.ReadAll(noTracking: true);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetProductsWithCategory()
        {
            var result = _query.ReadAll(noTracking: true, includeProperties: x => x.Category);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetProductsWithPagination([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var result = _query.ReadAll(noTracking: true, pagination: pagination =>
            {

                pagination.MaxPageSize = 50;
                pagination.PageNumber = pageNumber;
                pagination.PageSize = pageSize;
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var result = _query.ReadSingleOrDefault(true, x => x.Id == id);
            if(result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductWithCategory(int id)
        {
            var result = _query.ReadSingleOrDefault(true, x => x.Id == id, includeProperties: x => x.Category);
            if(result == null) return NotFound();
            return Ok(result);
        }


        // Async Commands


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductDto createProduct)
        {
            Product product = new()
            {
                DisplayName = createProduct.DisplayName,
                Price = createProduct.Price,
                CategoryId = createProduct.CategoryId,
            };

            var result = await _command.CreateAsync(product);

            await _command.ExecuteAsync();
            return Created("", result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ProductDto updateProduct)
        {
            var product = await _query.ReadFirstOrDefaultAsync(true, x => x.Id == id);
            if (product is null) return NotFound();

            product.DisplayName = updateProduct.DisplayName;
            product.Price = updateProduct.Price;
            product.CategoryId = updateProduct.CategoryId;

            await _command.EditAsync(product);
            await _command.ExecuteAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            IQueryable<Product> query = await _query.QueryAsync(true, filter: x => x.Id == id);
            Product product = query.SingleOrDefault();
            if (product == null) return NotFound();

            await _command.RemoveAsync(product);
            await _command.ExecuteAsync();
            return NoContent();
        }


        // Sync Commands

        [HttpPost]
        public IActionResult Create([FromBody] ProductDto createProduct)
        {
            Product product = new()
            {
                DisplayName = createProduct.DisplayName,
                Price = createProduct.Price,
                CategoryId = createProduct.CategoryId,
            };

            var result = _command.Create(product);
            _command.Execute();
            return Created("", result);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductDto updateProduct)
        {
            var product = _query.ReadFirstOrDefault(true, x => x.Id == id);
            if (product is null) return NotFound();

            product.DisplayName = updateProduct.DisplayName;
            product.Price = updateProduct.Price;
            product.CategoryId = updateProduct.CategoryId;

            _command.Edit(product);
            _command.Execute();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IQueryable<Product> query = _query.Query(true, filter: x => x.Id == id);
            Product product = query.SingleOrDefault();
            if (product == null) return NotFound();

            _command.Remove(product);
            _command.Execute();
            return NoContent();
        }
    }
```

