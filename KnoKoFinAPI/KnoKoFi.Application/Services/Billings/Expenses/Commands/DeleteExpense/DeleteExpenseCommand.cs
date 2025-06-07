using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Expenses.Commands.DeleteExpense
{
    public class DeleteExpenseCommand : IRequest
    {
        public long Id { get; set; }
    }
}
