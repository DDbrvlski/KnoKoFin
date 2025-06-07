using KnoKoFin.Application.Services.Billings.Expenses.Commands.CreateExpense;
using KnoKoFin.Application.Services.Billings.Expenses.Interfaces;
using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Interfaces.Repositories;
using KnoKoFin.Domain.Interfaces.Repositories.Billings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Expenses
{
    public class ExpenseAppService : IExpenseAppService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IBillingServiceRepository _billingServiceRepository;
        private readonly IGenericRepository<ExpensePosition> _genericExpensePositionRepository;
        public ExpenseAppService
            (IExpenseRepository expenseRepository,
            IBillingServiceRepository billingServiceRepository, 
            IGenericRepository<ExpensePosition> genericExpensePositionRepository)
        {
            _genericExpensePositionRepository = genericExpensePositionRepository;
            _expenseRepository = expenseRepository;
            _billingServiceRepository = billingServiceRepository;
        }

        public async Task<Expense> CreateExpenseAsync(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = CreateExpenseCommandMapper.MapCommandToExpense(request);
            var billingServices = CreateExpenseCommandMapper.MapCommandToBillingServiceList(request);

            var addedExpense = await _expenseRepository.CreateAsync(expense, cancellationToken);
            var addedBillingServices = await _billingServiceRepository.CreateManyAsync(billingServices, cancellationToken);

            List<ExpensePosition> expensePositions = new();

            foreach(var item in addedBillingServices)
            {
                expensePositions.Add(ExpensePosition.Create(addedExpense.Id, item.Id));
            }

            await _genericExpensePositionRepository.CreateManyAsync(expensePositions, cancellationToken);
            return expense;
        }
    }
}
