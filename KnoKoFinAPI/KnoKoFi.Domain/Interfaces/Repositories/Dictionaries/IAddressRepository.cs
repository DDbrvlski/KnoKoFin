using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Domain.Interfaces.Repositories.Dictionaries
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<IEnumerable<Address>> GetByCityAsync(string city);
        Task<IEnumerable<Address>> GetByPostCodeAsync(string postCode);
    }
}
