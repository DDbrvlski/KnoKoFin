using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Queries.GetServiceTypeList;
using KnoKoFin.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Interfaces.Repositories
{
    public interface IServiceTypeRepository : IGenericRepository<ServiceType>
    {
        Task<List<ServiceTypeDto>> GetAllServiceTypesAsync();
    }
}
