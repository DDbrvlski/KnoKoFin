using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingServices.Queries.GetBillingServiceDetails
{
    public interface IGetBillingServiceDetailsQueryRepository
    {
        Task<BillingServiceDetailsDto> GetBillingServiceDetailsAsync(long id, CancellationToken cancellationToken);
    }
}
