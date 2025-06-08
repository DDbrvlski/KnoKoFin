using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Billings.BillingServices.Dtos;
using KnoKoFin.Application.Services.Billings.BillingServices.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingServices.Queries.GetBillingServiceDetails
{
    public class GetBillingTransactionServiceDetailsQueryHandler : IRequestHandler<GetBillingTransactionServiceDetailsQuery, BillingTransactionServiceDetailsDto>
    {
        IGetBillingTransactionServiceDetailsQueryRepository _getBillingServiceDetailsQueryRepository;
        public GetBillingTransactionServiceDetailsQueryHandler
            (IGetBillingTransactionServiceDetailsQueryRepository getBillingServiceDetailsQueryRepository)
        {
            _getBillingServiceDetailsQueryRepository = getBillingServiceDetailsQueryRepository;
        }
        public async Task<BillingTransactionServiceDetailsDto> Handle(GetBillingTransactionServiceDetailsQuery request, CancellationToken cancellationToken)
        {
            var item = await _getBillingServiceDetailsQueryRepository.GetBillingTransactionServiceDetailsAsync(request.Id, cancellationToken);
            if (item == null)
            {
                throw new NotFoundException($"Nie znaleziono serwisu o podanym id: {request.Id}");
            }

            return item;
        }
    }
}
