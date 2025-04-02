using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Infrastructure.Common.Interfaces;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries.Addresses
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<IEnumerable<Address>> GetByCityAsync(string city);
        Task<IEnumerable<Address>> GetByPostCodeAsync(string postCode);
    }
}
