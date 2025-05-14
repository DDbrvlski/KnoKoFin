using KnoKoFin.Application.Common.Interfaces.Dictionaries.Addresses;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.CreateAddress;
using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress
{
    public static class UpdateAddressCommandMapper
    {
        public static Address UpdateAddressCommandToAddressMap(Address address, UpdateAddressCommand updateAddress)
        {
            address.Update(
                    updateAddress.City,
                    updateAddress.Country,
                    updateAddress.PostCode,
                    updateAddress.Street
                );

            return address;
        }

        public static UpdateAddressCommand AddressToUpdateAddressCommandMap(Address address)
        {
            return new UpdateAddressCommand()
            {
                Id = address.Id,
                City = address.City,
                Country = address.Country,
                PostCode = address.PostCode,
                Street = address.Street,
            };
        }

        public static CreateAddressCommand UpdateAddressCommandToCreateAddressCommandMap(UpdateAddressCommand addressCommand)
        {
            return new CreateAddressCommand()
            {
                City = addressCommand.City,
                Country = addressCommand.Country,
                PostCode = addressCommand.PostCode,
                Street = addressCommand.Street,
            };
        }

        public static UpdateAddressCommand CreateAddressCommandToUpdateAddressCommandMap(CreateAddressCommand createAddress)
        {
            var address = new UpdateAddressCommand()
            {
                City = createAddress.City,
                Country = createAddress.Country,
                PostCode = createAddress.PostCode,
                Street = createAddress.Street,
            };

            if (createAddress.Id.HasValue)
            {
                address.Id = createAddress.Id.Value;
            }

            return address;
        }
    }
}
