using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Enums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KnoKoFin.Application.Services.Billings.BillingServices.Commands.CreateBillingService
{
    public static class CreateBillingServiceCommandMapper
    {
        public static BillingService MapCommandToBillingService(CreateBillingServiceCommand request, CancellationToken cancellationToken)
        {
            //Przenieść do validatora
            if (!Enum.TryParse<UnityTypeEnum>(request.Unit, true, out var unitType))
            {
                throw new ArgumentException($"Nieprawidłowy typ jednostki miary: {request.Unit}");
            }

            return BillingService.Create
                (
                    request.Name,
                    request.Description,
                    request.Discount,
                    request.NetPrice,
                    request.GrossPrice,
                    request.Vat,
                    unitType,
                    request.Quantity,
                    request.ServiceTypeId
                );
        }
    }
}
