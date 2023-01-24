namespace Identity.Core.Interfaces.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    void Save();
}