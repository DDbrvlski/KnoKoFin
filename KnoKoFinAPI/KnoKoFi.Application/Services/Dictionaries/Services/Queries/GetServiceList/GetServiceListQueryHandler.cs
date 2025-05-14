using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Queries.GetServiceTypeList;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Services.Queries.GetServiceList
{
    public class GetServiceListQueryHandler : IRequestHandler<GetServiceListQuery, ServiceList>
    {
        private readonly IDictionaryServiceRepository _serviceRepository;
        public GetServiceListQueryHandler(IDictionaryServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<ServiceList> Handle(GetServiceListQuery request, CancellationToken cancellationToken)
        {
            var query = _serviceRepository.GetAll();
            return await GetServiceListQueryMapper.GetServiceList(query, cancellationToken);
        }
    }
}
