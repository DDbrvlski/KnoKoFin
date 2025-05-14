using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries
{
    public class TransactionTypeRepository : GenericRepository<TransactionType>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(KnoKoFinContext context, ILogger<GenericRepository<TransactionType>> logger)
            : base(context, logger) { }
    }
}
