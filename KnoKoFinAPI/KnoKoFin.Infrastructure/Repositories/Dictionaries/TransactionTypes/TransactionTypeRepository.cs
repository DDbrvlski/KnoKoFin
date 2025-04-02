using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries.TransactionTypes
{
    public class TransactionTypeRepository : GenericRepository<TransactionType>
    {
        public TransactionTypeRepository(KnoKoFinContext context, ILogger<GenericRepository<TransactionType>> logger)
            : base(context, logger) { }
    }
}
