using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Billings.Expenses.Interfaces;
using KnoKoFin.Domain.Interfaces;
using KnoKoFin.Domain.Interfaces.Repositories.Billings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Expenses.Commands.DeleteExpense
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand>
    {
        private readonly IExpenseAppService _expenseAppService;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteExpenseCommandHandler
            (IExpenseAppService expenseAppService,
            IUnitOfWork unitOfWork)
        {
            _expenseAppService = expenseAppService;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                await _expenseAppService.ArchiveExpenseAsync(request, cancellationToken);

                await _unitOfWork.CommitTransactionAsync();
            }
            catch(Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new DeleteFailureException($"Wystąpił błąd podczas usuwania wydatku");
            }
        }
    }
}
