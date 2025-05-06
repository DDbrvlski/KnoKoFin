using KnoKoFin.Domain.Shared.Dtos;

namespace KnoKoFin.Application.Common.Interfaces.Dictionaries.ServiceTypes
{
    public interface IServiceTypeQueryRepository
    {
        Task<List<ServiceTypeDto>> GetAllServiceTypesAsync();
    }
}
