using KnoKoFin.Application.Services.Billings.BillingServices.Commands.CreateBillingService;
using KnoKoFin.Application.Services.Billings.BillingTransactionServices.Dtos;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dto;
using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingTransactionServices.Commands.UpdateBillingTransactionService
{
    public static class UpdateBillingTransactionServiceCommandMapper
    {
        public static BillingTransactionService ApplyUpdate(BillingTransactionService entity, UpdateBillingTransactionServiceCommand request)
        {
            //Przenieść do validatora
            if (!Enum.TryParse<UnityTypeEnum>(request.Unit, true, out var unitType))
            {
                throw new ArgumentException($"Nieprawidłowy typ jednostki miary: {request.Unit}");
            }

            entity.Update
                (request.Name,
                request.Description,
                request.Discount,
                request.NetPrice,
                request.GrossPrice,
                request.Vat,
                unitType,
                request.Quantity,
                request.ServiceTypeId);

            return entity;
        }

        public static UpdateBillingTransactionServiceResultDto BillingServiceToUpdateResultDto(BillingTransactionService entity)
        {

            return new UpdateBillingTransactionServiceResultDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Discount = entity.Discount,
                NetPrice = entity.NetPrice,
                GrossPrice = entity.GrossPrice,
                Vat = entity.Vat,
                Unit = entity.Unit.ToString(),
                Quantity = entity.Quantity,
                ServiceTypeId = entity.ServiceTypeId,
                CreatedAt = entity.CreatedAt,
                LastModifiedAt = entity.UpdatedAt,
                RowVersion = entity.RowVersion
            };

        }
    }
