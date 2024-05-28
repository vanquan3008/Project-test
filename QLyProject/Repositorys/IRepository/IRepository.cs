using System.Linq.Expressions;

namespace QLyProject.Repositorys.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllByQueryAsync(Expression<Func<T, bool>>? filter = null);
        Task<T?> CreateAsync(T entity);
        Task DeleteByIdAsync(int id);
        Task DeleteAsync(T entity);
        Task<T?> UpdateAsync(T entity);
    }
}
