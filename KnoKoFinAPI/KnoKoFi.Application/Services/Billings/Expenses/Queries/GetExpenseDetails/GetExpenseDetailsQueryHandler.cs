using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Billings.Expenses.Dtos;
using KnoKoFin.Application.Services.Billings.Expenses.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Expenses.Queries.GetExpenseDetails
{
    public class GetExpenseDetailsQueryHandler : IRequestHandler<GetExpenseDetailsQuery, ExpenseDetailsDto>
    {
        private readonly IGetExpenseDetailsQueryRepository _getExpenseDetailsQueryRepository;
        public GetExpenseDetailsQueryHandler(IGetExpenseDetailsQueryRepository getExpenseDetailsQueryRepository)
        {
            _getExpenseDetailsQueryRepository = getExpenseDetailsQueryRepository;
        }

        public async Task<ExpenseDetailsDto> Handle(GetExpenseDetailsQuery request, CancellationToken cancellationToken)
        {
            var expenseDetails = await _getExpenseDetailsQueryRepository.GetExpenseDetailsAsync(request.Id, cancellationToken);
            if(expenseDetails == null)
            {
                throw new NotFoundException("Nie znaleziono szczegółów danego wydatku.");
            }
            return expenseDetails;
        }
    }
}
