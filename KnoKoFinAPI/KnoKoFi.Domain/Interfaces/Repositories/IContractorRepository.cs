using KnoKoFin.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Domain.Interfaces.Repositories
{
    public interface IContractorRepository : IGenericRepository<Contractor>
    {
        Task<GetContractorAddressIdDto?> GetContractorAddressId(long contractorId);
    }
}
