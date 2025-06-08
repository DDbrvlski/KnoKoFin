using KnoKoFin.Application.Services.Billings.Expenses.Dtos;
using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KnoKoFin.Application.Services.Billings.Expenses.Commands.UpdateExpense
{
    public static class UpdateExpenseCommandMapper
    {
        public static Expense ApplyUpdate(Expense expense, UpdateExpenseCommand command)
        {
            expense
                .Update(
                command.Name,
                command.Description,
                command.PurchaseDate,
                command.TotalNetPrice,
                command.TotalGrossPrice,
                command.ContractorId,
                command.TransactionTypeId);

            return expense;
        }

        public static List<BillingTransactionService> UpdateBillingServiceDtoToBillingTransactionService(List<UpdateBillingServiceDto> items, long? expenseId)
        {
            List<BillingTransactionService> billingServices = new();

            foreach (var item in items)
            {
                if (!Enum.TryParse<UnityTypeEnum>(item.Unit, true, out var unitType))
                {
                    throw new ArgumentException($"Nieprawidłowy typ jednostki miary: {item.Unit}");
                }
                billingServices
                    .Add(BillingTransactionService
                        .Create(item.Name,
                        item.Description,
                        item.Discount,
                        item.NetPrice,
                        item.GrossPrice,
                        item.Vat,
                        unitType,
                        item.Quantity,
                        item.ServiceTypeId,
                        null,
                        expenseId));
            }

            return billingServices;
        }

        public static List<UpdateBillingServiceDto> billingTransactionServiceToUpdateBillingServiceDto(List<BillingTransactionService> items)
        {
            List<UpdateBillingServiceDto> updateBillingServiceDtos = new();

            foreach (var item in items)
            {
                updateBillingServiceDtos.Add(new UpdateBillingServiceDto()
                {
                    Description = item.Description,
                    Discount = item.Discount,
                    NetPrice = item.NetPrice,
                    GrossPrice = item.GrossPrice,
                    Vat = item.Vat,
                    Id = item.Id,
                    Name = item.Name,
                    Quantity = item.Quantity,
                    Unit = item.Unit.ToString(),
                    ServiceTypeId = item.ServiceTypeId
                });
            }

            return updateBillingServiceDtos;
        }

        public static UpdateExpenseResultDto ExpenseToUpdateExpenseResultDto(Expense expense)
        {
            return new UpdateExpenseResultDto
            {
                Id = expense.Id,
                Description = expense.Description,
                PurchaseDate = expense.PurchaseDate,
                ContractorId = expense.ContractorId,
                Name = expense.Name,
                TotalGrossPrice = expense.TotalGrossPrice,
                TotalNetPrice = expense.TotalNetPrice,
                TransactionTypeId = expense.TransactionTypeId
            };
        }
    }
}   
