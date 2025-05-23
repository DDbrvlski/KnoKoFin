using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.Services.Commands.CreateService
{
    public class CreateServiceCommandMapper
    {
        public DictionaryService CommandToService(CreateServiceCommand command)
        {
            return DictionaryService.Create
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
