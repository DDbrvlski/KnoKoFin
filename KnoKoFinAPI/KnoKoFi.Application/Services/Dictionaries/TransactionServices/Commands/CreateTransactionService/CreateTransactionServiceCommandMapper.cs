using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServices.Commands.CreateTransactionService
{
    public class CreateTransactionServiceCommandMapper
    {
        public DictionaryTransactionService CommandToService(CreateTransactionServiceCommand command)
        {
            return DictionaryTransactionService.Create
                (command.Name,
                command.Description,
                command.Discount,
                command.NetPrice,
                command.GrossPrice,
                command.Vat,
                command.Unit,
                command.Quantity);
        }

        //public CreateServiceDto Map(DictionaryService service)
        //{
        //    return new CreateServiceDto()
        //    {
        //        Id = service.Id,
        //        Name = service.Name,
        //        Description = service.Description,
        //        Discount = service.Discount,
        //        NetPrice = service.NetPrice,
        //        GrossPrice = service.GrossPrice,
        //        Vat = service.Vat,
        //        Unit = service.Unit,
        //        Quantity = service.Quantity
        //    };
        //}
    }
}
