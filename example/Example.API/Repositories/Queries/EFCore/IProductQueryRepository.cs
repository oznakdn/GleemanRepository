using Example.API.Models;
using Gleeman.Repository.EFCore.Interfaces.Query;

namespace Example.API.Repositories.Queries.EFCore;

public interface IProductQueryRepository : IEFQueryAsyncRepository<Product>, IEFQuerySyncRepository<Product>
{
}
