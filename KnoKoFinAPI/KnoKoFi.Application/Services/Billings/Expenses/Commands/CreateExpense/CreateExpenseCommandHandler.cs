using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Billings.Expenses.Interfaces;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.CreateContractor;
using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Interfaces;
using KnoKoFin.Domain.Interfaces.Repositories.Billings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Expenses.Commands.CreateExpense
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExpenseAppService _expenseAppService;
        public CreateExpenseCommandHandler
            (IUnitOfWork unitOfWork,
            IExpenseAppService expenseAppService)
        {
            _unitOfWork = unitOfWork;
            _expenseAppService = expenseAppService;
        }
        public async Task<long> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var addedExpense = await _expenseAppService.CreateExpenseAsync(request, cancellationToken);

                await _unitOfWork.CommitTransactionAsync();

                return addedExpense.Id;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new CreateFailureException(nameof(Expense), request, $"Wystąpił błąd podczas tworzenia: {ex.Message}");
            }
        }
    }
}
