namespace Practices.Domain.Entities;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public IEnumerable<Book>? Books { get; set; }
}
