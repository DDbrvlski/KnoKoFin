using KnoKoFin.Application.Interfaces.Repositories;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries.Addresses
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(KnoKoFinContext context, ILogger<GenericRepository<Address>> logger) 
            : base(context, logger) { }

        public async Task<IEnumerable<Address>> GetByCityAsync(string city)
            => await _dbSet.Where(a => a.City == city).ToListAsync();
        public async Task<IEnumerable<Address>> GetByPostCodeAsync(string postCode)
            => await _dbSet.Where(a => a.PostCode == postCode).ToListAsync();
    }
}
