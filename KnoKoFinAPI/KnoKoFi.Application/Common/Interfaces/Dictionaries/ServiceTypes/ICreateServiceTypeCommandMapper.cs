using KnoKoFin.Application.Services.Dictionaries.TransactionServiceTypes.Commands.CreateTransactionServiceType;
using KnoKoFin.Application.Services.Dictionaries.TransactionServiceTypes.Dtos;
using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Common.Interfaces.Dictionaries.ServiceTypes
{
    public interface ICreateServiceTypeCommandMapper
    {
        TransactionServiceType Map(CreateTransactionServiceTypeCommand command);
        CreateTransactionServiceTypeResultDto Map(TransactionServiceType serviceType);
    }
}