﻿using KnoKoFin.Domain.Helpers;
using System.Linq.Expressions;

namespace KnoKoFin.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAll();
        Task<T?> GetByIdAsync(long id);
        Task<List<T>> CreateManyAsync(List<T> entities, CancellationToken cancellationToken);
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(long id, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(long id);
    }
}
