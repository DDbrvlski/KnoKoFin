using KnoKoFin.Application.Services.Billings.BillingServices.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingServices.Queries.GetBillingServiceList
{
    public class GetBillingServiceListQuery : IRequest<BillingServiceListDto>
    {
    }
}
