using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.CreateServiceType
{
    public static class CreateServiceTypeCommandMapper
    {
        public static ServiceType Map(CreateServiceTypeCommand command)
        {
            return ServiceType.Create(command.Name, command.Description);
        }
        public static CreateServiceTypeDto Map(ServiceType serviceType)
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
