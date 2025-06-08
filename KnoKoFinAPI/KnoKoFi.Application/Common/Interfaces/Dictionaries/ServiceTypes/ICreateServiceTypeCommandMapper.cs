using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.CreateServiceType;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dtos;
using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Common.Interfaces.Dictionaries.ServiceTypes
{
    public interface ICreateServiceTypeCommandMapper
    {
        TransactionServiceType Map(CreateTransactionServiceTypeCommand command);
        CreateTransactionServiceTypeResultDto Map(TransactionServiceType serviceType);
    }
}