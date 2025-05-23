using KnoKoFin.Application.Services.Dictionaries.Services.Dto;
using KnoKoFin.Application.Services.Dictionaries.Services.Interfaces;
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
    public class GetServiceListQueryHandler : IRequestHandler<GetServiceListQuery, ServiceListDto>
    {
        private readonly IGetServiceListRepository _serviceRepository;
        public GetServiceListQueryHandler(IGetServiceListRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<ServiceListDto> Handle(GetServiceListQuery request, CancellationToken cancellationToken)
        {
            return await _serviceRepository.GetServiceListAsync(cancellationToken);
        }
    }
}
