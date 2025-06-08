using KnoKoFin.Application.Services.Billings.Expenses.Commands.CreateExpense;
using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Revenues.Commands.CreateRevenue
{
    public static class CreateRevenueCommandMapper
    {
        public static Revenue MapCommandToRevenue(CreateRevenueCommand command)
        {

            return Revenue
                .Create
                (command.Name,
                command.Description,
                command.SaleDate,
                command.TotalNetPrice,
                command.TotalGrossPrice,
                command.ContractorId,
                command.TransactionTypeId);
        }
        public static List<BillingTransactionService> MapCommandToBillingServiceList(CreateRevenueCommand command, long? revenueId)
        {
            List<BillingTransactionService> billingServices = new();

            foreach (var service in command.BillingServices)
            {
                if (!Enum.TryParse<UnityTypeEnum>(service.Unit, true, out var unitType))
                {
                    throw new ArgumentException($"Nieprawidłowy typ jednostki miary: {service.Unit}");
                }
                billingServices
                    .Add(BillingTransactionService
                        .Create(service.Name,
                        service.Description,
                        service.Discount,
                        service.NetPrice,
                        service.GrossPrice,
                        service.Vat,
                        unitType,
                        service.Quantity,
                        service.ServiceTypeId,
                        revenueId,
                        null));
            }

            return billingServices;
        }
    }
}
