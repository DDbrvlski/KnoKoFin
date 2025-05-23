using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dto;
using KnoKoFin.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Interfaces
{
    public interface IGetServiceTypeListRepository
    {
        Task<ServiceTypeListDto> GetServiceTypeList(CancellationToken cancellationToken);
    }
}
