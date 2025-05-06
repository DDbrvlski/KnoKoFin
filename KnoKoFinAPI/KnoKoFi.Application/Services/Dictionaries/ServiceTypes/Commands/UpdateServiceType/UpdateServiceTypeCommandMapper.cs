using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.UpdateServiceType
{
    public class UpdateServiceTypeCommandMapper
    {
        public ServiceType Map(ServiceType serviceType, UpdateServiceTypeCommand command)
        {
            serviceType.Update(command.Name, command.Description);
            return serviceType;
        }

        public UpdateServiceTypeCommand Map(ServiceType serviceType)
        {
            return new UpdateServiceTypeCommand()
            {
                Id = serviceType.Id,
                Name = serviceType.Name,
                Description = serviceType.Description,
            };
        }
    }
}
