using Example.API.Data.Context;
using Example.API.Models;
using Gleeman.Repository.EFCore.Abstracts.Command;

namespace Example.API.Repositories.Commands.EFCore;

public class ProductCommandRepository : EFCommandRepository<Product, AppDbContext>, IProductCommandRepository
{
    public ProductCommandRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
