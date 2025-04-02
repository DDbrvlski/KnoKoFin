using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.CreateAddress
{
    public class CreateAddressMapper
    {
        public Address CreateAddressCommandToAddressMap(CreateAddressCommand command)
        {
            return Address.Create(
                command.City,
                command.Country,
                command.PostCode,
                command.Street
            );
        }

        public CreateAddressCommand AddressToCreateAddressCommandMap(Address address)
        {
            return new CreateAddressCommand()
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
