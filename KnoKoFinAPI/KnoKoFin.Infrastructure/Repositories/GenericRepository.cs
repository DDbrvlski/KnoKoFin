using KnoKoFin.Domain.Helpers;
using KnoKoFin.Infrastructure.Common.Exceptions;
using KnoKoFin.Infrastructure.Common.Interfaces;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace KnoKoFin.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        protected readonly KnoKoFinContext _context;
        protected readonly DbSet<T> _dbSet;
        private readonly ILogger<GenericRepository<T>> _logger;

        public GenericRepository(KnoKoFinContext context, ILogger<GenericRepository<T>> logger)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _logger = logger;
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        => await _dbSet.AnyAsync(predicate);

        public IQueryable<T> GetAll()
            => _dbSet.Where(x => x.IsActive);

        public async Task<IEnumerable<T>> GetAllAsync()
        => await _dbSet.Where(x => x.IsActive).ToListAsync();

        public async Task<T?> GetByIdAsync(long id)
            => await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
        public async Task<List<T>> CreateManyAsync(List<T> entities, CancellationToken cancellationToken)
        {
            try
            {
                foreach (var entity in entities)
                {
                    entity.IsActive = true;
                }
                await _dbSet.AddRangeAsync(entities);
                await _context.SaveChangesAsync(cancellationToken);
                return entities;
            }
            catch (DbUpdateException ex) when (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlEx)
            {
                _logger.LogError(sqlEx, "Błąd SQL podczas dodawania wielu encji {EntityName}. Numer błędu: {ErrorNumber}, Szczegóły: {ErrorMessage}",
                    typeof(T).Name, sqlEx.Number, sqlEx.Message);

                throw new DatabaseOperationException($"Błąd SQL podczas dodawania wielu encji {typeof(T).Name}.");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Błąd EF podczas dodawania wielu encji {EntityName}. Szczegóły: {ErrorMessage}",
                    typeof(T).Name, ex.Message);

                throw new DatabaseOperationException($"Błąd EF podczas dodawania wielu encji {typeof(T).Name}.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Nieoczekiwany błąd podczas dodawania wielu encji {EntityName}. Szczegóły: {ErrorMessage}",
                    typeof(T).Name, ex.Message);

                throw new DatabaseOperationException($"Nieoczekiwany błąd podczas dodawania wielu encji {typeof(T).Name}.");
            }
        }
        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken)
        {
            try
            {
                entity.IsActive = true;
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx)
            {
                _logger.LogError(sqlEx, "Błąd SQL podczas dodawania encji {EntityName}. Numer błędu: {ErrorNumber}, Szczegóły: {ErrorMessage}",
                    typeof(T).Name, sqlEx.Number, sqlEx.Message);

                throw new DatabaseOperationException($"Błąd SQL podczas dodawania encji {typeof(T).Name}.");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Błąd EF podczas dodawania encji {EntityName}. Szczegóły: {ErrorMessage}",
                    typeof(T).Name, ex.Message);

                throw new DatabaseOperationException($"Błąd EF podczas dodawania encji {typeof(T).Name}.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Nieoczekiwany błąd podczas dodawania encji {EntityName}. Szczegóły: {ErrorMessage}",
                    typeof(T).Name, ex.Message);

                throw new DatabaseOperationException($"Nieoczekiwany błąd podczas dodawania encji {typeof(T).Name}.");
            }
        }


        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx)
            {
                _logger.LogError(sqlEx, "Błąd SQL podczas aktualizacji encji {EntityName}. Numer błędu: {ErrorNumber}, Szczegóły: {ErrorMessage}",
                    typeof(T).Name, sqlEx.Number, sqlEx.Message);

                throw new DatabaseOperationException($"Błąd SQL podczas aktualizacji encji {typeof(T).Name}.");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Błąd EF podczas aktualizacji encji {EntityName}. Szczegóły: {ErrorMessage}",
                    typeof(T).Name, ex.Message);

                throw new DatabaseOperationException($"Błąd EF podczas aktualizacji encji {typeof(T).Name}.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Nieoczekiwany błąd podczas aktualizacji encji {EntityName}. Szczegóły: {ErrorMessage}",
                    typeof(T).Name, ex.Message);

                throw new DatabaseOperationException($"Nieoczekiwany błąd podczas aktualizacji encji {typeof(T).Name}.");
            }
        }


        public async Task DeleteAsync(long id, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                if (entity != null)
                {
                    entity.IsActive = false;
                    await _context.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    _logger.LogError($"Nie znaleziono encji {nameof(T)} o ID: {entity.Id}");
                    throw new NotFoundException(nameof(T), entity.Id);
                }
            }
            catch (DbUpdateException ex) when (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlEx)
            {
                _logger.LogError(sqlEx, "Błąd SQL podczas usuwania encji {EntityName}. Numer błędu: {ErrorNumber}, Szczegóły: {ErrorMessage}",
                    typeof(T).Name, sqlEx.Number, sqlEx.Message);

                throw new DatabaseOperationException($"Błąd SQL podczas usuwania encji {typeof(T).Name}.");
            }
        }

        public async Task<bool> ExistsAsync(long id)
        {
            return await _dbSet.AnyAsync(a => a.Id == id && a.IsActive);
        }
    }
}
