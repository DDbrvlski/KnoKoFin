using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Queries.GetServiceTypeList
{
    public class GetServiceTypeListQueryHandler : IRequestHandler<GetServiceTypeListQuery, ServiceTypeList>
    {
        private readonly IServiceTypeRepository _serviceTypeRepository;
        public GetServiceTypeListQueryHandler(IServiceTypeRepository serviceTypeRepository)
        {
            _serviceTypeRepository = serviceTypeRepository;
        }

        public async Task<ServiceTypeList> Handle(GetServiceTypeListQuery request, CancellationToken cancellationToken)
        {
            var query = _serviceTypeRepository.GetAll();
            return await GetServiceTypeListQueryMapper.GetServiceTypeList(query, cancellationToken);
        }
    }
}
