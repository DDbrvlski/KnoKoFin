using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnoKoFin.Application.Services.Billings.BillingServices.Dtos;

namespace KnoKoFin.Application.Services.Billings.BillingServices.Interfaces
{
    public interface IGetBillingServiceListQueryRepository
    {
        Task<BillingServiceListDto> GetBillingServiceListAsync(CancellationToken cancellationToken);
    }
}
