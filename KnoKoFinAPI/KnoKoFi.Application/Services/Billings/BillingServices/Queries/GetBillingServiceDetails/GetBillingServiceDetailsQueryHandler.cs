using KnoKoFin.Application.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingServices.Queries.GetBillingServiceDetails
{
    public class GetBillingServiceDetailsQueryHandler : IRequestHandler<GetBillingServiceDetailsQuery, BillingServiceDetailsDto>
    {
        IGetBillingServiceDetailsQueryRepository _getBillingServiceDetailsQueryRepository;
        public GetBillingServiceDetailsQueryHandler
            (IGetBillingServiceDetailsQueryRepository getBillingServiceDetailsQueryRepository)
        {
            _getBillingServiceDetailsQueryRepository = getBillingServiceDetailsQueryRepository;
        }
        public async Task<BillingServiceDetailsDto> Handle(GetBillingServiceDetailsQuery request, CancellationToken cancellationToken)
        {
            var item = await _getBillingServiceDetailsQueryRepository.GetBillingServiceDetailsAsync(request.Id, cancellationToken);
            if (item == null)
            {
                throw new NotFoundException($"Nie znaleziono serwisu o podanym id: {request.Id}");
            }

            return item;
        }
    }
}
