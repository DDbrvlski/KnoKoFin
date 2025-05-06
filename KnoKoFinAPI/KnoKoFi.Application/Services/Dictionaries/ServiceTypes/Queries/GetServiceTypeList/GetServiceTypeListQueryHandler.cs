using KnoKoFin.Application.Common.Interfaces.Dictionaries.ServiceTypes;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Queries.GetServiceTypeList
{
    public class GetServiceTypeListQueryHandler : IRequestHandler<GetServiceTypeListQuery, ServiceTypeList>
    {
        private readonly IGetServiceTypeListService _serviceTypeListService;
        public GetServiceTypeListQueryHandler(IGetServiceTypeListService getServiceTypeListService)
        {
            _serviceTypeListService = getServiceTypeListService;
        }

        public async Task<ServiceTypeList> Handle(GetServiceTypeListQuery request, CancellationToken cancellationToken)
        {
            return await _serviceTypeListService.GetAllServices();
        }
    }
}
