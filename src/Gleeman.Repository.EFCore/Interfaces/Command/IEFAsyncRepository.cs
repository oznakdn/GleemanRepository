namespace Gleeman.Repository.EFCore.Interfaces.Command;

public interface IEFAsyncRepository:IAsyncDisposable
{
    Task<int> ExecuteAsync(CancellationToken cancellationToken=default(CancellationToken));
}
