using Microsoft.EntityFrameworkCore;
using Practices.Domain.Entities;
using Practices.Domain.IRepositories;
using Practices.Infrastructure.DBContext;

namespace Practices.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;
    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Book entity)
    {
        _context.Add(entity);
    }

    public void Update(Book entity)
    {
        _context.Update(entity);
    }

    public void Delete(int id)
    {
        var Book = _context.Books.Find(id);
        if (Book != null)
        {
            _context.Books.Remove(Book);
        }
    }

    public async Task<IEnumerable<Book>> GetAll()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book?> GetById(int id)
    {
        return await _context.Books.FirstOrDefaultAsync(e => e.Id == id);
    }
}
