using KnoKoFi.Application.Interfaces.Dictionaries;
using KnoKoFin.API.Repositories.Dictionaries.Addresses;
using KnoKoFin.DTOs.Dictionaries.Addresses;
using KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries;
using System.ComponentModel.DataAnnotations;

namespace KnoKoFin.API.Services.Dictionaries
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;

        public AddressService(IAddressRepository repository)
            => _repository = repository;

        public async Task<Address> CreateAsync(CreateAddressDTO newAddress)
        {
            if (await _repository.AnyAsync(a =>
                a.Street == newAddress.Street &&
                a.PostCode == newAddress.PostCode.Replace(" ", "")))
            {
                throw new ValidationException("Adres już istnieje");
            }


            return createdAddress;
        }


        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<Address> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Address address)
        {
            await _repository.UpdateAsync(address);
        }
    }
}
