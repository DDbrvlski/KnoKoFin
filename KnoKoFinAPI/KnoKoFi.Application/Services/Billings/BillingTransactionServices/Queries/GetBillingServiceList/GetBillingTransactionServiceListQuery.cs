using KnoKoFin.Application.Services.Billings.BillingTransactionServices.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingTransactionServices.Queries.GetBillingServiceList
{
    public class GetBillingTransactionServiceListQuery : IRequest<BillingTransactionServiceListDto>
    {
    }
}
