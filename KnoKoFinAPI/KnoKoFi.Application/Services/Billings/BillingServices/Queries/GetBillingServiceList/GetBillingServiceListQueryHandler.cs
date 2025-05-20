using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingServices.Queries.GetBillingServiceList
{
    public class GetBillingServiceListQueryHandler : IRequestHandler<GetBillingServiceListQuery, BillingServiceList>
    {
        private readonly IGetBillingServiceListQueryRepository _getBillingServiceListQueryRepository;
        public GetBillingServiceListQueryHandler(IGetBillingServiceListQueryRepository getBillingServiceListQueryRepository)
        {
            _getBillingServiceListQueryRepository = getBillingServiceListQueryRepository;
        }
        public async Task<BillingServiceList> Handle(GetBillingServiceListQuery request, CancellationToken cancellationToken)
        {
            var items = await _getBillingServiceListQueryRepository.GetBillingServiceListAsync(cancellationToken);
            return items;
        }
    }
}
