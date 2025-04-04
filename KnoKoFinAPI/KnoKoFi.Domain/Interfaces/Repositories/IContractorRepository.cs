using KnoKoFin.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Interfaces.Repositories
{
    public interface IContractorRepository : IGenericRepository<Contractor>
    {
        Task<long?> GetContractorAddressId(long contractorId);
    }
}
