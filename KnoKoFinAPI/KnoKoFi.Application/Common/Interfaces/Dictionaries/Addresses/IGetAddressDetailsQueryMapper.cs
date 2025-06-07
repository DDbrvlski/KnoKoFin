using KnoKoFin.Application.Services.Dictionaries.Addresses.Dtos;
using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Common.Interfaces.Dictionaries.Addresses
{
    public interface IGetAddressDetailsQueryMapper
    {
        AddressDetailsDto Map(Address address);
    }
}