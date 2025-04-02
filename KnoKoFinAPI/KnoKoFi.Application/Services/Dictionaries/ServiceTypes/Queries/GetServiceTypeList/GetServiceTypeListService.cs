using KnoKoFin.Application.Common.Interfaces.Dictionaries.ServiceTypes;
using KnoKoFin.Infrastructure.Repositories.Dictionaries.ServiceTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var serviceTypes = await _serviceTypeRepository.GetAll().Map().ToListAsync();
            return new ServiceTypeList() { ServiceTypes = serviceTypes };
        }
    }
}
