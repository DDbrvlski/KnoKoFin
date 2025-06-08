using KnoKoFin.Application.Services.Billings.BillingTransactionServices.Dtos;
using KnoKoFin.Application.Services.Billings.BillingTransactionServices.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingTransactionServices.Queries.GetBillingServiceList
{
    public class GetBillingTransactionServiceListQueryHandler : IRequestHandler<GetBillingTransactionServiceListQuery, BillingTransactionServiceListDto>
    {
        private readonly IGetBillingTransactionServiceListQueryRepository _getBillingServiceListQueryRepository;
        public GetBillingTransactionServiceListQueryHandler(IGetBillingTransactionServiceListQueryRepository getBillingServiceListQueryRepository)
        {
            _getBillingServiceListQueryRepository = getBillingServiceListQueryRepository;
        }
        public async Task<BillingTransactionServiceListDto> Handle(GetBillingTransactionServiceListQuery request, CancellationToken cancellationToken)
        {
            var items = await _getBillingServiceListQueryRepository.GetBillingTransactionServiceListAsync(cancellationToken);
            return items;
        }
    }
}
