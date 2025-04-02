using KnoKoFin.Application.Common.Interfaces.Dictionaries.ServiceTypes;
using KnoKoFin.Infrastructure.Repositories.Dictionaries.ServiceTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
