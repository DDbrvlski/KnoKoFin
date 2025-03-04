using KnoKoFin.API.Middleware.Exceptions;
using KnoKoFin.Infrastructure.Persistence;
using KnoKoFin.Infrastructure.Persistence.Configurations.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KnoKoFin.API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        protected readonly KnoKoFinContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(KnoKoFinContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        => await _dbSet.AnyAsync(predicate);

        public async Task<IEnumerable<T>> GetAllAsync()
        => await _dbSet.Where(x => x.IsActive).ToListAsync();

        public async Task<T?> GetByIdAsync(long id)
            => await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                entity.IsActive = false;
                await UpdateAsync(entity);
            }
        }

        public async Task SaveChangesAsync()
        {
            await DatabaseOperationHandler.TryToSaveChangesAsync(_context);
        }
    }
}
