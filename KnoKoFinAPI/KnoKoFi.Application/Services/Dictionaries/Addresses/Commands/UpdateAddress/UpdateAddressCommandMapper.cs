using KnoKoFin.Application.Common.Interfaces.Dictionaries.Addresses;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.CreateAddress;
using KnoKoFin.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandMapper : IUpdateAddressMapper
    {
        public Address UpdateAddressCommandToAddressMap(Address address, UpdateAddressCommand updateAddress)
        {
            address.Update(
                    updateAddress.City,
                    updateAddress.Country,
                    updateAddress.PostCode,
                    updateAddress.Street
                );

            return address;
        }

        public UpdateAddressCommand AddressToUpdateAddressCommandMap(Address address)
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

        public CreateAddressCommand UpdateAddressCommandToCreateAddressCommandMap(UpdateAddressCommand addressCommand)
        {
            return new CreateAddressCommand()
            {
                City = addressCommand.City,
                Country = addressCommand.Country,
                PostCode = addressCommand.PostCode,
                Street = addressCommand.Street,
            };
        }

        public UpdateAddressCommand CreateAddressCommandToUpdateAddressCommandMap(CreateAddressCommand createAddress)
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
