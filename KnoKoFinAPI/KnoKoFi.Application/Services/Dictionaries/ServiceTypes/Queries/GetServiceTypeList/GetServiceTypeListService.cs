using KnoKoFin.Application.Common.Interfaces.Dictionaries.ServiceTypes;
using KnoKoFin.Application.Interfaces.Repositories;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Queries.GetServiceTypeList
{
    public class GetServiceTypeListService : IGetServiceTypeListService
    {
        private readonly IServiceTypeRepository _serviceTypeRepository;
        public GetServiceTypeListService(IServiceTypeRepository serviceTypeRepository)
        {
            _serviceTypeRepository = serviceTypeRepository;
        }

        public async Task<ServiceTypeList> GetAllServices()
        {
            var serviceTypes = await _serviceTypeRepository.GetAllServiceTypesAsync();
            return new ServiceTypeList() { ServiceTypes = serviceTypes };
        }
    }
}
