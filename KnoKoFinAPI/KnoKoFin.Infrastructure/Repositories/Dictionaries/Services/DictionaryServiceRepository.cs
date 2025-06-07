using KnoKoFin.Application.Services.Dictionaries.Services.Dtos;
using KnoKoFin.Application.Services.Dictionaries.Services.Interfaces;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries.Services
{
    public class DictionaryServiceRepository : GenericRepository<DictionaryService>, IGetServiceDetailsRepository, IGetServiceListRepository
    {
        public DictionaryServiceRepository(KnoKoFinContext context, ILogger<GenericRepository<DictionaryService>> logger)
            : base(context, logger) { }

        public async Task<ServiceDetailsDto> GetServiceDetailsAsync(long id, CancellationToken cancellationToken)
        {
            var serviceDetailsDto = await GetSingle(id).Select(x => new ServiceDetailsDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Discount = x.Discount,
                GrossPrice = x.GrossPrice,
                NetPrice = x.NetPrice,
                Quantity = x.Quantity,
                ServiceTypeName = x.ServiceType.Name,
                Unit = x.Unit,
                Vat = x.Vat,
                CreatedAt = x.CreatedAt,
                LastModifiedAt = x.UpdatedAt,
                RowVersion = x.RowVersion
            }).FirstOrDefaultAsync(cancellationToken);

            return serviceDetailsDto;
        }

        public async Task<ServiceListDto> GetServiceListAsync(CancellationToken cancellationToken)
        {
            var items = await GetAll()
            .Select(x => new ServiceDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ServiceTypeName = x.ServiceType.Name
            })
            .ToListAsync(cancellationToken);

            return new ServiceListDto() { Services = items };
        }
    }
}
