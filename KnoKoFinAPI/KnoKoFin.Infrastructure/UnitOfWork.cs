using KnoKoFin.API.Repositories;
using KnoKoFin.Infrastructure.Persistence;
using KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure
{
    public class UnitOfWork
    {
        private KnoKoFinContext _context = new KnoKoFinContext();

        private GenericRepository<Address> _addressRepository;

        private IDbContextTransaction? _transaction;
        public GenericRepository<Address> AddressRepository
        {
            get
            {

                if (this._addressRepository == null)
                {
                    this._addressRepository = new GenericRepository<Address>(_context);
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
