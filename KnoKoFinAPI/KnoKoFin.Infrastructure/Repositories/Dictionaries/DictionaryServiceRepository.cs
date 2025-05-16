using KnoKoFin.Application.Services.Dictionaries.Services.Queries.GetServiceDetails;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries
{
    public class DictionaryServiceRepository : GenericRepository<DictionaryService>, IGetServiceDetailsRepository
    {
        public DictionaryServiceRepository(KnoKoFinContext context, ILogger<GenericRepository<DictionaryService>> logger)
            : base(context, logger) { }

        public Task<ServiceDetailsDto> GetServiceDetailsAsync(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
