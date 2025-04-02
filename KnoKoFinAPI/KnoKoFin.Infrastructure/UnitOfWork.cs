using KnoKoFin.Infrastructure.Common.Interfaces;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KnoKoFinContext _context;
        private readonly ILoggerFactory _loggerFactory;

        private IDbContextTransaction? _transaction;

        public UnitOfWork(KnoKoFinContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _loggerFactory = loggerFactory;
        }
        
        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }

}
