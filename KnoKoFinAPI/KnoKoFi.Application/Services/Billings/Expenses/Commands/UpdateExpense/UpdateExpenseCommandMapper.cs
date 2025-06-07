using KnoKoFin.Application.Services.Billings.Expenses.Dtos;
using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Expenses.Commands.UpdateExpense
{
    public static class UpdateExpenseCommandMapper
    {
        public static Expense ApplyUpdate(Expense expense, UpdateExpenseCommand command)
        {
            var transactionType = Enum.Parse<TransactionTypeEnum>(command.TransactionType, true);
            expense
                .Update(
                command.Name,
                command.Description,
                command.PurchaseDate,
                command.TotalNetPrice,
                command.TotalGrossPrice,
                command.ContractorId,
                transactionType);

            return expense;
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
                TransactionType = expense.TransactionType.ToString()
            };
        }
    }
}   
