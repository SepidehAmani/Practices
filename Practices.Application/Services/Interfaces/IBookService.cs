using Practices.Application.DTOs;

namespace Practices.Application.Services.Interfaces;

public interface IBookService
{
    Task<AuthorWithBooksDTO?> GetAuthorWithBooksById(int id, CancellationToken cancellation);
    Task<BookDTO?> GetBookById(int id, CancellationToken cancellation);
    Task<AuthorWithBooksDTO?> CreateAuthor(CreateAuthorDTO authorDTO, CancellationToken cancellation);
    Task<BookDTO?> CreateBook(int authorId, CreateBookDTO bookDTO, CancellationToken cancellation);
}
