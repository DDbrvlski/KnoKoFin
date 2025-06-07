using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnoKoFin.Application.Services.Billings.BillingServices.Dtos;

namespace KnoKoFin.Application.Services.Billings.BillingServices.Interfaces
{
    public interface IGetBillingServiceDetailsQueryRepository
    {
        Task<BillingServiceDetailsDto> GetBillingServiceDetailsAsync(long id, CancellationToken cancellationToken);
    }
}
