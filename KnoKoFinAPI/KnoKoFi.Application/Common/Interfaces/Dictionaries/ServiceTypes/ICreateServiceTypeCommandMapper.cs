using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.CreateServiceType;
using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Common.Interfaces.Dictionaries.ServiceTypes
{
    public interface ICreateServiceTypeCommandMapper
    {
        ServiceType Map(CreateServiceTypeCommand command);
        CreateServiceTypeDto Map(ServiceType serviceType);
    }
}