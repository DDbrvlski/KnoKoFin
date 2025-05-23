using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dto;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Interfaces;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Queries.GetServiceTypeList
{
    public class GetServiceTypeListQueryHandler : IRequestHandler<GetServiceTypeListQuery, ServiceTypeListDto>
    {
        private readonly IGetServiceTypeListRepository _serviceTypeRepository;
        public GetServiceTypeListQueryHandler(IGetServiceTypeListRepository serviceTypeRepository)
        {
            _serviceTypeRepository = serviceTypeRepository;
        }

        public async Task<ServiceTypeListDto> Handle(GetServiceTypeListQuery request, CancellationToken cancellationToken)
        {
            return await _serviceTypeRepository.GetServiceTypeList(cancellationToken);
        }
    }
}
