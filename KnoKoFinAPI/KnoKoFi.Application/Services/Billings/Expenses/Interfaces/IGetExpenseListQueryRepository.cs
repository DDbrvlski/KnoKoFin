using KnoKoFin.Application.Services.Billings.Expenses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Expenses.Interfaces
{
    public interface IGetExpenseListQueryRepository
    {
        Task<ExpenseListDto> GetExpenseListAsync(CancellationToken cancellationToken);
    }
}
