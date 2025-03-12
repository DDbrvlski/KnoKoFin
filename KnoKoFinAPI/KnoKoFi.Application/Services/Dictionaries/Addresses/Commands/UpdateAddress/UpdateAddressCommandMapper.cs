using KnoKoFin.Application.Common.Interfaces.Dictionaries.Addresses;
using KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandMapper : IUpdateAddressMapper
    {
        public Address InputMap(Address address, UpdateAddressCommand updateAddress)
        {
            address.Update(
                    updateAddress.City,
                    updateAddress.Country,
                    updateAddress.PostCode,
                    updateAddress.Street
                );

            return address;
        }

        public UpdateAddressCommand OutputMap(Address address)
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
    }
}
