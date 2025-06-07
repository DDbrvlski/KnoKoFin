using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dtos;
using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.CreateServiceType
{
    public static class CreateServiceTypeCommandMapper
    {
        public static ServiceType CommandToServiceType(CreateServiceTypeCommand command)
        {
            return ServiceType.Create(command.Name, command.Description);
        }
        public static CreateServiceTypeResultDto ServiceTypeToServiceTypeDto(ServiceType serviceType)
        {
            return new CreateServiceTypeResultDto()
            {
                Id = serviceType.Id,
                Name = serviceType.Name,
                Description = serviceType.Description
            };
        }
    }
}
