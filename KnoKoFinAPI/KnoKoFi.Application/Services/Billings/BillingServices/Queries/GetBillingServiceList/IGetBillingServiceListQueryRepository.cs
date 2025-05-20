using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingServices.Queries.GetBillingServiceList
{
    public interface IGetBillingServiceListQueryRepository
    {
        Task<BillingServiceList> GetBillingServiceListAsync(CancellationToken cancellationToken);
    }
}
