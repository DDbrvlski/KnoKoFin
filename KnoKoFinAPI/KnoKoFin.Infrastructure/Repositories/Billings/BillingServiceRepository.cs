using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Infrastructure.Repositories.Billings
{
    public class BillingServiceRepository : GenericRepository<BillingService>
    {
        public BillingServiceRepository(KnoKoFinContext context, ILogger<GenericRepository<BillingService>> logger) : base(context, logger)
        {
        }
    }
}
