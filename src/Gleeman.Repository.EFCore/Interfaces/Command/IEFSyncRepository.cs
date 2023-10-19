namespace Gleeman.Repository.EFCore.Interfaces.Command;

public interface IEFSyncRepository:IDisposable
{
    int Execute();
}
