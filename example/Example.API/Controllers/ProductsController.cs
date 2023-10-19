using Example.API.Dtos;
using Example.API.Models;
using Example.API.Repositories.Commands;
using Example.API.Repositories.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Controllers
{
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
}
