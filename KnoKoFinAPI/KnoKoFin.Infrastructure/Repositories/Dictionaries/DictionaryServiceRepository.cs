using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries
{
    public class DictionaryServiceRepository : GenericRepository<DictionaryService>
    {
        public DictionaryServiceRepository(KnoKoFinContext context, ILogger<GenericRepository<DictionaryService>> logger)
            : base(context, logger) { }
    }
}
