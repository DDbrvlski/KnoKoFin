using KnoKoFin.API.Repositories.Dictionaries.Addresses;
using KnoKoFin.Database.Models.Dictionaries;
using KnoKoFin.DTOs.Dictionaries.Addresses;
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

            var addressEntity = _mapper.Map<Address>(newAddress);

            var createdAddress = await _repository.CreateAsync(addressEntity);
            await _repository.SaveChangesAsync();

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
