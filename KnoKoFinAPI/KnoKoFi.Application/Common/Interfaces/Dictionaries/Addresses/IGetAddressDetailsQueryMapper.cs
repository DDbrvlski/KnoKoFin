using KnoKoFin.Application.DTOs.Dictionaries.Addresses;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Queries.GetAddressList;
using KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries;

namespace KnoKoFin.Application.Common.Interfaces.Dictionaries.Addresses
{
    public interface IGetAddressDetailsQueryMapper
    {
        AddressDetailsDto Map(Address address);
    }
}