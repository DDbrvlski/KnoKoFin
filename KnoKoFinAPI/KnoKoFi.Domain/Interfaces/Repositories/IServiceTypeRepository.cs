using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Domain.Interfaces.Repositories
{
    public interface IServiceTypeRepository : IGenericRepository<ServiceType>
    {
        Task<List<ServiceTypeDto>> GetAllServiceTypesAsync();
    }
}
