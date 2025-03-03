using KnoKoFin.Database.Context;
using KnoKoFin.Database.Models.Dictionaries;
using Microsoft.EntityFrameworkCore;

namespace KnoKoFin.API.Repositories.Dictionaries.Addresses
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(KnoKoFinContext context) : base(context) { }

        public async Task<IEnumerable<Address>> GetByCityAsync(string city)
            => await _dbSet.Where(a => a.City == city).ToListAsync();
        public async Task<IEnumerable<Address>> GetByPostCodeAsync(string postCode)
            => await _dbSet.Where(a => a.PostCode == postCode).ToListAsync();
    }
}
