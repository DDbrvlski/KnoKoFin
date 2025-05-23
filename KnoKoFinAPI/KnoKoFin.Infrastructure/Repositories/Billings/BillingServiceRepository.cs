using KnoKoFin.Application.Services.Billings.BillingServices.Dto;
using KnoKoFin.Application.Services.Billings.BillingServices.Interfaces;
using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Interfaces.Repositories.Billings;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Infrastructure.Repositories.Billings
{
    public class BillingServiceRepository : 
        GenericRepository<BillingService>, 
        IBillingServiceRepository,
        IGetBillingServiceDetailsQueryRepository,
        IGetBillingServiceListQueryRepository
    {
        public BillingServiceRepository(KnoKoFinContext context, ILogger<GenericRepository<BillingService>> logger) : base(context, logger)
        {
        }

        public async Task<BillingServiceDetailsDto> GetBillingServiceDetailsAsync(long id, CancellationToken cancellationToken)
        {
            var entity = await GetSingle(id)
                .Select(x => new BillingServiceDetailsDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Discount = x.Discount,
                    CreatedAt = x.CreatedAt,
                    GrossPrice = x.GrossPrice,
                    NetPrice = x.NetPrice,
                    Quantity = x.Quantity,
                    RowVersion = x.RowVersion,
                    ServiceTypeId = x.ServiceTypeId,
                    ServiceTypeName = x.ServiceType.Name,
                    LastModifiedAt = x.UpdatedAt,
                    Unit = x.Unit,
                    Vat = x.Vat
                }).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<BillingServiceListDto> GetBillingServiceListAsync(CancellationToken cancellationToken)
        {
            var items = await GetAll()
                .Select(x => new BillingServiceDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ServiceTypeName = x.ServiceType.Name
                }).ToListAsync(cancellationToken);

            return new BillingServiceListDto() { BillingServices = items };
        }
    }
}
