using Identity.Core.Interfaces.UnitOfWork;

namespace Identity.Infrastructure.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDataContext _context;

    public UnitOfWork(AppDataContext context)
    {
        _context = context;
    }

    public void Save()
    {
        using var dbcontext = _context.Database.BeginTransaction();
        try
        {
            _context.SaveChanges();
            dbcontext.Commit();
        }
        catch (Exception)
        {
            dbcontext.Rollback();
        }
    }

    private bool disposed;
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}