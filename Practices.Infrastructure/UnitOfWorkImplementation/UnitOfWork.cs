using Practices.Domain.IRepositories;
using Practices.Domain.UnitOfWorkInterface;
using Practices.Infrastructure.DBContext;

namespace Practices.Infrastructure.UnitOfWorkImplementation;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IAuthorRepository Authors { get; }
    public IBookRepository Books { get; }

    public UnitOfWork(AppDbContext context, IAuthorRepository authorRepository, IBookRepository bookRepository)
    {
        _context = context;
        Authors = authorRepository;
        Books = bookRepository;
    }

    public void Dispose()
    {
        _context.DisposeAsync();
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }
}
