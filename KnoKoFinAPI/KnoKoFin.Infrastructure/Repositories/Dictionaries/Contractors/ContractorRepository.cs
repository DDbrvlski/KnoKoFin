using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries.Contractors
{
    public class ContractorRepository : GenericRepository<Contractor>, IContractorRepository
    {
        public ContractorRepository(KnoKoFinContext context, ILogger<GenericRepository<Contractor>> logger)
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
