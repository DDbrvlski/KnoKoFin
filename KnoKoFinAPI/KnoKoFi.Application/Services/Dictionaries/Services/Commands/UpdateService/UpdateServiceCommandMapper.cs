using KnoKoFin.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Services.Commands.UpdateService
{
    public class UpdateServiceCommandMapper
    {
        public DictionaryService Map(DictionaryService service, UpdateServiceCommand updateService)
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

        public UpdateServiceDto Map(DictionaryService service)
        {
            return new UpdateServiceDto()
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
            };
        }
    }
}
