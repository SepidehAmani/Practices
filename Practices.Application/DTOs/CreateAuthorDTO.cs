using Practices.Domain.Entities;

namespace Practices.Application.DTOs;

public class CreateAuthorDTO
{
    public string Name { get; set; }
    public IEnumerable<CreateBookDTO>? Books { get; set; }
}
