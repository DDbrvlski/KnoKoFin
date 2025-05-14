using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Infrastructure.Repositories.Billings
{
    public class ExpensePositionRepository : GenericRepository<ExpensePosition>
    {
        public ExpensePositionRepository(KnoKoFinContext context, ILogger<GenericRepository<ExpensePosition>> logger) : base(context, logger)
        {
        }
    }
}
