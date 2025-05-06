using KnoKoFin.Application.Common.Interfaces.Dictionaries.ServiceTypes;
using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.CreateServiceType
{
    public class CreateServiceTypeCommandMapper : ICreateServiceTypeCommandMapper
    {
        public ServiceType Map(CreateServiceTypeCommand command)
        {
            return ServiceType.Create(command.Name, command.Description);
        }
        public CreateServiceTypeDto Map(ServiceType serviceType)
        {
            return new CreateServiceTypeDto()
            {
                Id = serviceType.Id,
                Name = serviceType.Name,
                Description = serviceType.Description
            };
        }
    }
}
