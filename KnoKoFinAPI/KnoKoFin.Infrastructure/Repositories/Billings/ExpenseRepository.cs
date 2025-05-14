using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Infrastructure.Repositories.Billings
{
    public class ExpenseRepository : GenericRepository<Expense>
    {
        public ExpenseRepository(KnoKoFinContext context, ILogger<GenericRepository<Expense>> logger) : base(context, logger)
        {
        }
    }
}
