using KnoKoFin.Database.Models.Dictionaries;
using KnoKoFin.DTOs.Dictionaries.Addresses;

namespace KnoKoFin.API.Services.Dictionaries
{
    public interface IAddressService
    {
        Task<Address> GetByIdAsync(long id);
        Task CreateAsync(CreateAddressDTO newAddress);
        Task UpdateAsync(Address address);
        Task DeleteAsync(long id);
    }
}
