using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnoKoFin.Application.Services.Dictionaries.Services.Dto;

namespace KnoKoFin.Application.Services.Dictionaries.Services.Interfaces
{
    public interface IGetServiceDetailsRepository
    {
        Task<ServiceDetailsDto> GetServiceDetailsAsync(long id, CancellationToken cancellationToken);
    }
}
