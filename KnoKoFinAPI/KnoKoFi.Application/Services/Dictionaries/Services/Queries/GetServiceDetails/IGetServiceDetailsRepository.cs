using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Services.Queries.GetServiceDetails
{
    public interface IGetServiceDetailsRepository
    {
        Task<ServiceDetailsDto> GetServiceDetailsAsync(long id, CancellationToken cancellationToken);
    }
}
