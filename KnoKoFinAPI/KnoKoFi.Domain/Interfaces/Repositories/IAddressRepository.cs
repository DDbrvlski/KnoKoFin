using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Interfaces.Repositories
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<IEnumerable<Address>> GetByCityAsync(string city);
        Task<IEnumerable<Address>> GetByPostCodeAsync(string postCode);
    }
}
