using KnoKoFin.Application.Services.Billings.BillingTransactionServices.Dtos;
using MediatR;

namespace KnoKoFin.Application.Services.Billings.BillingTransactionServices.Queries.GetBillingServiceDetails
{
    public class GetBillingTransactionServiceDetailsQuery : IRequest<BillingTransactionServiceDetailsDto>
    {
        public long Id { get; set; }
    }
}
