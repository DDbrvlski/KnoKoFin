using KnoKoFin.Application.Services.Dictionaries.TransactionServiceTypes.Dtos;
using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServiceTypes.Commands.CreateTransactionServiceType
{
    public static class CreateTransactionServiceTypeCommandMapper
    {
        public static TransactionServiceType CommandToServiceType(CreateTransactionServiceTypeCommand command)
        {
            return TransactionServiceType.Create(command.Name, command.Description);
        }
        public static CreateTransactionServiceTypeResultDto ServiceTypeToServiceTypeDto(TransactionServiceType serviceType)
        {
            return new CreateTransactionServiceTypeResultDto()
            {
                Id = serviceType.Id,
                Name = serviceType.Name,
                Description = serviceType.Description
            };
        }
    }
}
