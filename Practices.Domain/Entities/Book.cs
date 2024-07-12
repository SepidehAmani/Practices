namespace Practices.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public Author? Author { get; set; }
}
