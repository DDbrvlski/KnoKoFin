using KnoKoFin.Application.Common.Interfaces.Dictionaries.Addresses;
using KnoKoFin.Application.DTOs.Dictionaries.Addresses;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Queries.GetAddressList;
using KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Queries.GetAddressDetails
{
    public class GetAddressDetailsQueryMapper : IGetAddressDetailsQueryMapper
    {
        public AddressDetailsDto Map(Address address)
        {
            return new AddressDetailsDto()
            {
                Id = address.Id,
                City = address.City,
                Country = address.Country,
                Street = address.Street,
                Postcode = address.PostCode
            };
        }
    }
}
