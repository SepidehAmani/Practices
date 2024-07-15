using Microsoft.EntityFrameworkCore;
using Practices.Domain.Entities;
using Practices.Domain.IRepositories;
using Practices.Infrastructure.DBContext;

namespace Practices.Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _context;
    public AuthorRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Author entity)
    {
        _context.Add(entity);
    }

    public void Update(Author entity)
    {
        _context.Update(entity);
    }

    public void Delete(int id)
    {
        var author = _context.Authors.Find(id);
        if (author != null)
        {
            _context.Authors.Remove(author);
        }
    }

    public async Task<IEnumerable<Author>> GetAll()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task<Author?> GetById(int id)
    {
        return await _context.Authors.Where(e => e.Id == id).Include(e=> e.Books).FirstOrDefaultAsync();
    }
}
