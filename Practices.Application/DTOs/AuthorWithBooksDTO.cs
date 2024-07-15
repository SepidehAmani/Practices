using Practices.Domain.Entities;

namespace Practices.Application.DTOs;

public class AuthorWithBooksDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public IEnumerable<BookDTO>? Books { get; set; }
}
