﻿using KnoKoFin.Application.Services.Dictionaries.Services.Dto;
using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.Services.Commands.UpdateService
{
    public static class UpdateServiceCommandMapper
    {
        public static DictionaryService ApplyUpdate(DictionaryService service, UpdateServiceCommand updateService)
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

        public static UpdateServiceResultDto ServiceToUpdateServiceDto(DictionaryService service)
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
