using KnoKoFin.Domain.Entities.Billings;

namespace KnoKoFin.Application.Services.Billings.BillingServices.Commands.CreateBillingService
{
    public static class CreateBillingServiceCommandMapper
    {
        public static BillingService MapCommandToBillingService(CreateBillingServiceCommand request, CancellationToken cancellationToken)
        {
            return BillingService.Create
                (
                    request.Name,
                    request.Description,
                    request.Discount,
                    request.NetPrice,
                    request.GrossPrice,
                    request.Vat,
                    request.Unit,
                    request.Quantity,
                    request.ServiceTypeId
                );
        }
    }
}
