using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress;
using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Common.Interfaces.Dictionaries.Addresses
{
    public interface IUpdateAddressMapper
    {
        Address UpdateAddressCommandToAddressMap(Address address, UpdateAddressCommand updateAddress);
        UpdateAddressCommand AddressToUpdateAddressCommandMap(Address address);
    }
}