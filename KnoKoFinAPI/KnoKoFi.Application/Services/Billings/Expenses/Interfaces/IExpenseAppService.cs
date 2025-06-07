using KnoKoFin.Application.Services.Billings.Expenses.Commands.CreateExpense;
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
        Task<Expense> CreateExpenseAsync(CreateExpenseCommand request, CancellationToken cancellationToken);
    }
}
