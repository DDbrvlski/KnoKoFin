using KnoKoFin.Application.Services.Billings.BillingServices.Dtos;
using MediatR;

namespace KnoKoFin.Application.Services.Billings.BillingServices.Queries.GetBillingServiceDetails
{
    public class GetBillingTransactionServiceDetailsQuery : IRequest<BillingTransactionServiceDetailsDto>
    {
        public long Id { get; set; }
    }
}
