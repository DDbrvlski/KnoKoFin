using KnoKoFin.Database.Models.Helpers;
using System.Linq.Expressions;

namespace KnoKoFin.API.Repositories
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(long id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(long id);

        Task SaveChangesAsync();
    }
}
