using KnoKoFin.Infrastructure.Persistence;
using KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries;
using KnoKoFin.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure
{
    public class UnitOfWork
    {
        private readonly KnoKoFinContext _context;
        private readonly ILoggerFactory _loggerFactory;

        private GenericRepository<Address>? _addressRepository;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(KnoKoFinContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _loggerFactory = loggerFactory;
        }

        public GenericRepository<Address> AddressRepository
        {
            get
            {
                if (_addressRepository == null)
                {
                    var logger = _loggerFactory.CreateLogger<GenericRepository<Address>>();
                    _addressRepository = new GenericRepository<Address>(_context, logger);
                }
                return _addressRepository;
            }
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
