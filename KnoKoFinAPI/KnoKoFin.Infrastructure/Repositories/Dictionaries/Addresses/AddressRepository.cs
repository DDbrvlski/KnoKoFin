using KnoKoFin.Application.Services.Dictionaries.Addresses.Dto;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Interfaces;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries.Addresses
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository, IGetAddressDetailsRepository
    {
        public AddressRepository(KnoKoFinContext context, ILogger<GenericRepository<Address>> logger)
            : base(context, logger) { }

        public async Task<AddressDetailsDto> GetAddressDetailsAsync(long id, CancellationToken cancellationToken)
        {
            var address = await GetSingle(id)
                .Select(x => new AddressDetailsDto()
                {
                    Id = x.Id,
                    City = x.City,
                    Country = x.Country,
                    Postcode = x.PostCode,
                    Street = x.Street,
                    CreatedAt = x.CreatedAt,
                    LastModifiedAt = x.UpdatedAt,
                    RowVersion = x.RowVersion
                }).FirstOrDefaultAsync();

            return address;
        }

        public async Task<IEnumerable<Address>> GetByCityAsync(string city)
            => await _dbSet.Where(a => a.City == city).ToListAsync();
        public async Task<IEnumerable<Address>> GetByPostCodeAsync(string postCode)
            => await _dbSet.Where(a => a.PostCode == postCode).ToListAsync();
    }
}
