using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnoKoFin.Application.Services.Billings.BillingTransactionServices.Dtos;

namespace KnoKoFin.Application.Services.Billings.BillingTransactionServices.Interfaces
{
    public interface IGetBillingTransactionServiceListQueryRepository
    {
        Task<BillingTransactionServiceListDto> GetBillingTransactionServiceListAsync(CancellationToken cancellationToken);
    }
}
