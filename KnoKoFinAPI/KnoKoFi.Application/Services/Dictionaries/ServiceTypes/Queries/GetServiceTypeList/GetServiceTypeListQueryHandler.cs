using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Queries.GetServiceTypeList
{
    public class GetServiceTypeListQueryHandler : IRequestHandler<GetServiceTypeListQuery, ServiceTypeList>
    {
        private readonly IGetServiceTypeListRepository _serviceTypeRepository;
        public GetServiceTypeListQueryHandler(IGetServiceTypeListRepository serviceTypeRepository)
        {
            _serviceTypeRepository = serviceTypeRepository;
        }

        public async Task<ServiceTypeList> Handle(GetServiceTypeListQuery request, CancellationToken cancellationToken)
        {
            return await _serviceTypeRepository.GetServiceTypeList(cancellationToken);
        }
    }
}
