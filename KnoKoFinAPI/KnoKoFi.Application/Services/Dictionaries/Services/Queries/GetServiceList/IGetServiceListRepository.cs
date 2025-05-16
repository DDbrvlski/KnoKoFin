using KnoKoFin.Application.Services.Dictionaries.Services.Queries.GetServiceDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Services.Queries.GetServiceList
{
    public interface IGetServiceListRepository
    {
        Task<ServiceList> GetServiceListAsync(CancellationToken cancellationToken);
    }
}
