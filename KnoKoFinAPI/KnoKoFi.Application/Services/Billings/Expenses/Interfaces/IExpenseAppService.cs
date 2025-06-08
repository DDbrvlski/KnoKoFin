using KnoKoFin.Application.Services.Billings.Expenses.Commands.CreateExpense;
using KnoKoFin.Application.Services.Billings.Expenses.Commands.DeleteExpense;
using KnoKoFin.Application.Services.Billings.Expenses.Commands.UpdateExpense;
using KnoKoFin.Application.Services.Billings.Expenses.Dtos;
using KnoKoFin.Domain.Entities.Billings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Expenses.Interfaces
{
    public interface IExpenseAppService
    {
        Task ArchiveExpenseAsync(DeleteExpenseCommand request, CancellationToken cancellationToken);
        Task<Expense> CreateExpenseAsync(CreateExpenseCommand request, CancellationToken cancellationToken);
        Task<UpdateExpenseResultDto> UpdateExpenseAsync(UpdateExpenseCommand request, CancellationToken cancellationToken);
    }
}
