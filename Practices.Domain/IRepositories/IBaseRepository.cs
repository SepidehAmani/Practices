namespace Practices.Domain.IRepositories;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(int id);
    void Add(T entity);
    void Delete(int id);
    void Update(T entity);
}
