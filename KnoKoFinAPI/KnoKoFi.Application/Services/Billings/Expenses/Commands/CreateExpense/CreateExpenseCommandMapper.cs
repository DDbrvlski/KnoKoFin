using KnoKoFin.Application.Services.Billings.Revenues.Commands.CreateRevenue;
using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Expenses.Commands.CreateExpense
{
    public static class CreateExpenseCommandMapper
    {
        public static Expense MapCommandToExpense(CreateExpenseCommand command)
        {

            return Expense
                .Create
                (command.Name,
                command.Description,
                command.PurchaseDate,
                command.TotalNetPrice,
                command.TotalGrossPrice,
                command.ContractorId,
                command.TransactionTypeId);
        }
        public static List<BillingTransactionService> MapCommandToBillingServiceList(CreateRevenueCommand command, long? expenseId)
        {
            List<BillingTransactionService> billingServices = new();
            
            foreach(var service in command.BillingServices)
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
                        null,
                        expenseId));
            }

            return billingServices;
        }
    }
}
