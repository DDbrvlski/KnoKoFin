using KnoKoFin.Application.Services.Billings.BillingServices.Commands.CreateBillingService;
using KnoKoFin.Application.Services.Billings.BillingServices.Dto;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dto;
using KnoKoFin.Domain.Entities.Billings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingServices.Commands.UpdateBillingService
{
    public static class UpdateBillingServiceCommandMapper
    {
        public static BillingService ApplyUpdate(BillingService entity, UpdateBillingServiceCommand request)
        {
            entity.Update
                (request.Name,
                request.Description,
                request.Discount,
                request.NetPrice,
                request.GrossPrice,
                request.Vat,
                request.Unit,
                request.Quantity,
                request.ServiceTypeId);

            return entity;
        }

        public static UpdateBillingServiceResultDto BillingServiceToUpdateResultDto(BillingService entity)
        {
            return new UpdateBillingServiceResultDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Discount = entity.Discount,
                NetPrice = entity.NetPrice,
                GrossPrice = entity.GrossPrice,
                Vat = entity.Vat,
                Unit = entity.Unit,
                Quantity = entity.Quantity,
                ServiceTypeId = entity.ServiceTypeId,
                CreatedAt = entity.CreatedAt,
                LastModifiedAt = entity.UpdatedAt,
                RowVersion = entity.RowVersion
            };
        
    }
}
