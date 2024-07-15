namespace Practices.Application.DTOs;

public class BookDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
}
