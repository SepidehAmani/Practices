using Practices.Domain.Entities;

namespace Practices.Domain.IRepositories;

public interface IBookRepository : IBaseRepository<Book>
{
    void AddBook(int authorId, Book book);
}
