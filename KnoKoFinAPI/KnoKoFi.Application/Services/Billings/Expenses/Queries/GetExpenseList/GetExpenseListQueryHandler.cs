using KnoKoFin.Application.Services.Billings.Expenses.Dtos;
using KnoKoFin.Application.Services.Billings.Expenses.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Expenses.Queries.GetExpenseList
{
    public class GetExpenseListQueryHandler : IRequestHandler<GetExpenseListQuery, ExpenseListDto>
    {
        private readonly IGetExpenseListQueryRepository _getExpenseListQueryRepository;
        public GetExpenseListQueryHandler(IGetExpenseListQueryRepository getExpenseListQueryRepository)
        {
            _getExpenseListQueryRepository = getExpenseListQueryRepository;
        }

        public Task<ExpenseListDto> Handle(GetExpenseListQuery request, CancellationToken cancellationToken)
        {
            
        }
    }
}
