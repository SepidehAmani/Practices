using Practices.Domain.Entities;

namespace Practices.Domain.IRepositories;

public interface IAuthorRepository : IBaseRepository<Author>
{
    Task<Author?> GetByName(string name, CancellationToken cancellation);
}
