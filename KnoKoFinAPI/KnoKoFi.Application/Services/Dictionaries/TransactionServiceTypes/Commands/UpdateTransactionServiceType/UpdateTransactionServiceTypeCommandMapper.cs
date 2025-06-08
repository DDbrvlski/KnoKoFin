using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dtos;
using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.UpdateServiceType
{
    public static class UpdateTransactionServiceTypeCommandMapper
    {
        public static TransactionServiceType ApplyUpdate(TransactionServiceType serviceType, UpdateTransactionServiceTypeCommand command)
        {
            serviceType.Update(command.Name, command.Description);
            return serviceType;
        }

        public static UpdateTransactionServiceTypeResultDto ServiceTypeToUpdateResultDto(TransactionServiceType serviceType)
        {
            return new UpdateTransactionServiceTypeResultDto()
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
