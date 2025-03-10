using KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.CreateAddress
{
    public class CreateAddressMapper
    {
        public Address Map(CreateAddressCommand command)
        {
            return Address.Create(
                command.City,
                command.Country,
                command.PostCode,
                command.Street
            );
        }
    }
}
