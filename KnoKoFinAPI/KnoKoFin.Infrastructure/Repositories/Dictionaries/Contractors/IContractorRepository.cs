using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Infrastructure.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries.Contractors
{
    public interface IContractorRepository : IGenericRepository<Contractor>
    {
        Task<GetContractorAddressIdDto?> GetContractorAddressId(long contractorId);
    }
}
