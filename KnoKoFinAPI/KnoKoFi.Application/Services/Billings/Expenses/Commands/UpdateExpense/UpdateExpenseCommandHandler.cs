using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Billings.BillingServices.Commands.UpdateBillingService;
using KnoKoFin.Application.Services.Billings.Expenses.Dtos;
using KnoKoFin.Domain.Interfaces.Repositories.Billings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Expenses.Commands.UpdateExpense
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, UpdateExpenseResultDto>
    {
        private readonly IExpenseRepository _expenseRepository;
        public UpdateExpenseCommandHandler(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<UpdateExpenseResultDto> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var oldEntity = await _expenseRepository.GetByIdAsync(request.Id, cancellationToken);
            if (oldEntity == null)
            {
                throw new NotFoundException("Wystąpił błąd - nie znaleziono wybranego wydatku.");
            }

            UpdateExpenseCommandMapper.ApplyUpdate(oldEntity, request);

            var newEntity = await _expenseRepository.UpdateAsync(oldEntity, cancellationToken);
            return UpdateExpenseCommandMapper.ExpenseToUpdateExpenseResultDto(newEntity);
        }
    }
}
