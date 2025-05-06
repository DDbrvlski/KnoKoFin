using KnoKoFin.Application.Common.Interfaces.Dictionaries.ServiceTypes;


namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Queries.GetServiceTypeList
{
    public class GetServiceTypeListService : IGetServiceTypeListService
    {
        private readonly IServiceTypeQueryRepository _serviceTypeRepository;
        public GetServiceTypeListService(IServiceTypeQueryRepository serviceTypeRepository)
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
