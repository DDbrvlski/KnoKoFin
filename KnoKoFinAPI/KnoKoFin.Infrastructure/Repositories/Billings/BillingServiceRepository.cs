using KnoKoFin.Application.Services.Billings.BillingServices.Queries.GetBillingServiceDetails;
using KnoKoFin.Application.Services.Billings.BillingServices.Queries.GetBillingServiceList;
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
                    
                }).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<BillingServiceList> GetBillingServiceListAsync(CancellationToken cancellationToken)
        {
            var items = await GetAll()
                .Select(x => new BillingServiceDto(){
                
                }).ToListAsync(cancellationToken);

            return new BillingServiceList() { BillingServices = items };
        }
    }
}
