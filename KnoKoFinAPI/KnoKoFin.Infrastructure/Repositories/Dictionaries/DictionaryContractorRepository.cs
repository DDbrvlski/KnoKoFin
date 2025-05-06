using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Interfaces.Repositories;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries
{
    public class DictionaryContractorRepository : GenericRepository<DictionaryContractor>, IContractorRepository
    {
        public DictionaryContractorRepository(KnoKoFinContext context, ILogger<GenericRepository<DictionaryContractor>> logger)
            : base(context, logger) { }

        public async Task<GetContractorAddressIdDto?> GetContractorAddressId(long contractorId)
        {
            return await _dbSet.Where(x => x.Id == contractorId)
                .Select(x => new GetContractorAddressIdDto()
                {
                    ContractorId = x.Id,
                    AddressId = x.AddressId
                }).FirstOrDefaultAsync();
        }
    }
}
