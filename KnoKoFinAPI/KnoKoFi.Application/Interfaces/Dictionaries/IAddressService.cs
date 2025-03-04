using KnoKoFin.DTOs.Dictionaries.Addresses;
using KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries;

namespace KnoKoFi.Application.Interfaces.Dictionaries
{
    public interface IAddressService
    {
        Task<Address> GetByIdAsync(long id);
        Task CreateAsync(CreateAddressDTO newAddress);
        Task UpdateAsync(Address address);
        Task DeleteAsync(long id);
    }
}
