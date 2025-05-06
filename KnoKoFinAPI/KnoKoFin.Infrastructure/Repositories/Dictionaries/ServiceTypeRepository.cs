using KnoKoFin.Application.Common.Interfaces.Dictionaries.ServiceTypes;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Interfaces.Repositories;
using KnoKoFin.Domain.Shared.Dtos;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;
using System.Data.Entity;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries
{
    public class ServiceTypeRepository : GenericRepository<ServiceType>, IServiceTypeRepository, IServiceTypeQueryRepository
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
