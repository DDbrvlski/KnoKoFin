using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Infrastructure.Repositories.Billings
{
    public class RevenuePositionRepository : GenericRepository<RevenuePosition>
    {
        public RevenuePositionRepository(KnoKoFinContext context, ILogger<GenericRepository<RevenuePosition>> logger) : base(context, logger)
        {
        }
    }
}
