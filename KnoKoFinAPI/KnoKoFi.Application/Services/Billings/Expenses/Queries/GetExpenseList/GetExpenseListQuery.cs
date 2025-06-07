using KnoKoFin.Application.Services.Billings.Expenses.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Expenses.Queries.GetExpenseList
{
    public class GetExpenseListQuery : IRequest<ExpenseListDto>
    {
    }
}
