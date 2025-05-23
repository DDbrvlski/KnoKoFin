using KnoKoFin.Application.Services.Billings.BillingServices.Dto;
using MediatR;

namespace KnoKoFin.Application.Services.Billings.BillingServices.Queries.GetBillingServiceDetails
{
    public class GetBillingServiceDetailsQuery : IRequest<BillingServiceDetailsDto>
    {
        public long Id { get; set; }
    }
}
