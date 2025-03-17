using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T?> AddAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync(Expression<Func<T, bool>> expression);
        Task<bool> UpdateAsync(T entity);
    }
}