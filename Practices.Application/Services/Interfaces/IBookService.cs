using Practices.Application.DTOs;

namespace Practices.Application.Services.Interfaces;

public interface IBookService
{
    Task<AuthorWithBooksDTO?> GetAuthorWithBooksById(int id, CancellationToken cancellation);
    Task<BookDTO?> GetBookById(int id, CancellationToken cancellation);
}
