using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.UpdateServiceType
{
    public static class UpdateServiceTypeCommandMapper
    {
        public static ServiceType ApplyUpdate(ServiceType serviceType, UpdateServiceTypeCommand command)
        {
            serviceType.Update(command.Name, command.Description);
            return serviceType;
        }

        public static UpdateServiceTypeCommand ToCommand(ServiceType serviceType)
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
