using Practices.Domain.IRepositories;

namespace Practices.Domain.UnitOfWorkInterface;

public interface IUnitOfWork : IDisposable
{
    IAuthorRepository Authors { get; }
    IBookRepository Books { get; }
    Task SaveChangesAsync(CancellationToken cancellation);
}
