using KnoKoFin.Application.Common.Interfaces.Dictionaries.Addresses;
using KnoKoFin.Domain.Entities.Dictionaries;

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
