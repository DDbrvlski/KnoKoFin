using KnoKoFin.Application.Services.Billings.Expenses.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Expenses.Queries.GetExpenseDetails
{
    public class GetExpenseDetailsQuery : IRequest<ExpenseDetailsDto>
    {
        public long Id { get; set; }
    }
}
