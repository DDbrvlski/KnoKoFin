using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Infrastructure.Repositories.Billings
{
    public class RevenueRepository : GenericRepository<Revenue>
    {
        public RevenueRepository(KnoKoFinContext context, ILogger<GenericRepository<Revenue>> logger) : base(context, logger)
        {
        }
    }
}
