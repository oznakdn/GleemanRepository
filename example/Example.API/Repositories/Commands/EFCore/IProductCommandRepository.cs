using Example.API.Models;
using Gleeman.Repository.EFCore.Interfaces.Command;
using Gleeman.Repository.EFCore.Interfaces.Command.Create;
using Gleeman.Repository.EFCore.Interfaces.Command.Delete;
using Gleeman.Repository.EFCore.Interfaces.Command.Update;

namespace Example.API.Repositories.Commands.EFCore;

public interface IProductCommandRepository :
IEFCreateAsyncRepository<Product>,
IEFCreateSyncRepository<Product>,
IEFUpdateAsyncRepository<Product>,
IEFUpdateSyncRepository<Product>,
IEFDeleteAsyncRepository<Product>,
IEFDeleteSyncRepository<Product>
{

}
