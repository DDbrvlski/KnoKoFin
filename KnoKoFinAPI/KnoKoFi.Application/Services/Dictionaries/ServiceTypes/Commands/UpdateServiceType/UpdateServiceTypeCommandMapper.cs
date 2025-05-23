using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dto;
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

        public static UpdateServiceTypeResultDto ServiceTypeToUpdateResultDto(ServiceType serviceType)
        {
            return new UpdateServiceTypeResultDto()
            {
                Id = serviceType.Id,
                Name = serviceType.Name,
                Description = serviceType.Description,
                CreatedAt = serviceType.CreatedAt,
                LastModifiedAt = serviceType.UpdatedAt,
                RowVersion = serviceType.RowVersion,
            };
        }
    }
}
