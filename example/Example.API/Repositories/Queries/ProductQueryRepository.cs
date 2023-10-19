using Example.API.Data.Context;
using Example.API.Models;
using Gleeman.Repository.EFCore.Abstracts.Query;

namespace Example.API.Repositories.Queries;

public class ProductQueryRepository : EFQueryRepository<Product, AppDbContext>, IProductQueryRepository
{
    public ProductQueryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
