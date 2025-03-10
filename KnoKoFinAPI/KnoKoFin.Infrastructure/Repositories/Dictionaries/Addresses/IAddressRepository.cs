using KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries;
using KnoKoFin.Infrastructure.Repositories;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries.Addresses
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<IEnumerable<Address>> GetByCityAsync(string city);
        Task<IEnumerable<Address>> GetByPostCodeAsync(string postCode);
    }
}
