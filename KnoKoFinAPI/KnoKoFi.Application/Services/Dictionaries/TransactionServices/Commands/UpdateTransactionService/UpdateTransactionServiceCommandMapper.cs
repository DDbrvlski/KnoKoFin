using KnoKoFin.Application.Services.Dictionaries.TransactionServices.Dtos;
using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServices.Commands.UpdateTransactionService
{
    public static class UpdateTransactionServiceCommandMapper
    {
        public static DictionaryTransactionService ApplyUpdate(DictionaryTransactionService service, UpdateTransactionServiceCommand updateService)
        {
            service.Update
                (updateService.Name,
                updateService.Description,
                updateService.Discount,
                updateService.NetPrice,
                updateService.GrossPrice,
                updateService.Vat,
                updateService.Unit,
                updateService.Quantity);

            return service;
        }

        public static UpdateServiceResultDto ServiceToUpdateServiceDto(DictionaryTransactionService service)
        {
            return new UpdateServiceResultDto()
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                Discount = service.Discount,
                NetPrice = service.NetPrice,
                GrossPrice = service.GrossPrice,
                Vat = service.Vat,
                Unit = service.Unit,
                Quantity = service.Quantity,
                CreatedAt = service.CreatedAt,
                LastModifiedAt = service.UpdatedAt,
                RowVersion = service.RowVersion,
            };
        }
    }
}
