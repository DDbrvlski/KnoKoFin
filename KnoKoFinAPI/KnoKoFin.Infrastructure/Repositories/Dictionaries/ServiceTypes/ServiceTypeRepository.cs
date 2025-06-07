using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dto;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dtos;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Interfaces;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries.ServiceTypes
{
    public class ServiceTypeRepository : GenericRepository<ServiceType>, IServiceTypeRepository, IGetServiceTypeListRepository
    {
        public ServiceTypeRepository(KnoKoFinContext context, ILogger<GenericRepository<ServiceType>> logger)
            : base(context, logger) { }

        public async Task<ServiceTypeListDto> GetServiceTypeList(CancellationToken cancellationToken)
        {
            var items = await GetAll()
                .Select(x => new ServiceTypeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                })
                .ToListAsync(cancellationToken);

            return new ServiceTypeListDto() { ServiceTypes = items };
        }
    }
}
