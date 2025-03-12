using KnoKoFin.Infrastructure.Persistence;
using KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries.Contractors
{
    public class ContractorRepository : GenericRepository<Contractor>
    {
        public ContractorRepository(KnoKoFinContext context, ILogger<GenericRepository<Contractor>> logger)
            : base(context, logger) { }
    }
}
