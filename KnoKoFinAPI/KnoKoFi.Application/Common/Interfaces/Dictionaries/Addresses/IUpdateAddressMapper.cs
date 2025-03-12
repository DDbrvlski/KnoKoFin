using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress;
using KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries;

namespace KnoKoFin.Application.Common.Interfaces.Dictionaries.Addresses
{
    public interface IUpdateAddressMapper
    {
        Address InputMap(Address address, UpdateAddressCommand updateAddress)
        UpdateAddressCommand OutputMap(Address address);
    }
}