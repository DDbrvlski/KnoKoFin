using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Shared.Dtos;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries.ServiceTypes
{
    public class ServiceTypeRepository : GenericRepository<ServiceType>, IServiceTypeRepository
    {
        public ServiceTypeRepository(KnoKoFinContext context, ILogger<GenericRepository<ServiceType>> logger)
            : base(context, logger) { }

        public async Task<List<ServiceTypeDto>> GetAllServiceTypesAsync()
        {
            return await GetAll().Select(serviceType => new ServiceTypeDto
            {
                Id = serviceType.Id,
                Name = serviceType.Name,
                Description = serviceType.Description,
            }).ToListAsync();
        }
    }
}
