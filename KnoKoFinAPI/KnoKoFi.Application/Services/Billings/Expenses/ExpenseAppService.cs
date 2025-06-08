using KnoKoFin.Application.Services.Billings.Expenses.Commands.CreateExpense;
using KnoKoFin.Application.Services.Billings.Expenses.Commands.DeleteExpense;
using KnoKoFin.Application.Services.Billings.Expenses.Commands.UpdateExpense;
using KnoKoFin.Application.Services.Billings.Expenses.Dtos;
using KnoKoFin.Application.Services.Billings.Expenses.Interfaces;
using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Interfaces.Repositories;
using KnoKoFin.Domain.Interfaces.Repositories.Billings;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Expenses
{
    public class ExpenseAppService : IExpenseAppService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IBillingTransactionServiceRepository _billingTransactionServiceRepository;
        public ExpenseAppService
            (IExpenseRepository expenseRepository,
            IBillingTransactionServiceRepository billingTransactionServiceRepository)
        {
            _expenseRepository = expenseRepository;
            _billingTransactionServiceRepository = billingTransactionServiceRepository;
        }

        public async Task<Expense> CreateExpenseAsync(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = CreateExpenseCommandMapper.MapCommandToExpense(request);
            var addedExpense = await _expenseRepository.CreateAsync(expense, cancellationToken);

            var billingServices = CreateExpenseCommandMapper.MapCommandToBillingServiceList(request, expense.Id);
            var addedBillingServices = await _billingTransactionServiceRepository.CreateManyAsync(billingServices, cancellationToken);

            return expense;
        }

        public async Task ArchiveExpenseAsync(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var billingServicesToArchive = await _billingTransactionServiceRepository.GetBillingTransactionServiceForExpenseAsync(request.Id, cancellationToken);
            await _expenseRepository.DeleteAsync(request.Id, cancellationToken);
            await _billingTransactionServiceRepository.DeleteManyAsync(billingServicesToArchive, cancellationToken);
        }

        public async Task<UpdateExpenseResultDto> UpdateExpenseAsync(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _expenseRepository.GetByIdAsync(request.Id, cancellationToken);
            UpdateExpenseCommandMapper.ApplyUpdate(expense, request);
            var updatedExpense = await _expenseRepository.UpdateAsync(expense, cancellationToken);

            var updatedExpenseResult = UpdateExpenseCommandMapper.ExpenseToUpdateExpenseResultDto(expense);

            await UpdateBillingTransactionServices(updatedExpenseResult, cancellationToken);

            return updatedExpenseResult;
        }

        private async Task UpdateBillingTransactionServices
            (UpdateExpenseResultDto updateExpenseResultDto,
            CancellationToken cancellationToken)
        {
            var expenseBillingServices = await _billingTransactionServiceRepository
                .GetBillingTransactionServiceForExpenseAsync(updateExpenseResultDto.Id, cancellationToken);

            var expenseBillingServicesIds = expenseBillingServices.Select(x => x.Id).ToList();
            var billingServicesWithIds = updateExpenseResultDto.BillingServices.Where(x => x.Id != null).ToList();

            var billingServicesToArchive = billingServicesWithIds.Where(x => !expenseBillingServicesIds.Contains((long)x.Id)).ToList();
            var billingServicesToUpdate = billingServicesWithIds.Where(x => expenseBillingServicesIds.Contains((long)x.Id)).ToList();
            var billingServicesToAdd = updateExpenseResultDto.BillingServices.Where(x => x.Id == null).ToList();

            await CreateBillingTransactionServices(updateExpenseResultDto, billingServicesToAdd, cancellationToken);
            await UpdateBillingTransactionServices(updateExpenseResultDto, billingServicesToUpdate, cancellationToken);
            await ArchiveBillingTransactionServices(updateExpenseResultDto, billingServicesToArchive, cancellationToken);


        }

        private async Task CreateBillingTransactionServices
            (UpdateExpenseResultDto updateExpenseResultDto,
            List<UpdateBillingServiceDto> billingServicesToAdd,
            CancellationToken cancellationToken)
        {
            if (billingServicesToAdd.Any())
            {
                var bSTAdd = UpdateExpenseCommandMapper
                    .UpdateBillingServiceDtoToBillingTransactionService(billingServicesToAdd, updateExpenseResultDto.Id);

                var newBillingServices = await _billingTransactionServiceRepository.CreateManyAsync(bSTAdd, cancellationToken);

                updateExpenseResultDto.BillingServices
                    .AddRange(UpdateExpenseCommandMapper.billingTransactionServiceToUpdateBillingServiceDto(newBillingServices));
            }
        }

        private async Task UpdateBillingTransactionServices
            (UpdateExpenseResultDto updateExpenseResultDto,
            List<UpdateBillingServiceDto> billingServicesToUpdate,
            CancellationToken cancellationToken)
        {
            if (billingServicesToUpdate.Any())
            {
                var bSTU = UpdateExpenseCommandMapper
                    .UpdateBillingServiceDtoToBillingTransactionService(billingServicesToUpdate, updateExpenseResultDto.Id);
                var updatedBillingServices = await _billingTransactionServiceRepository.UpdateManyAsync(bSTU, cancellationToken);

                updateExpenseResultDto.BillingServices
                    .AddRange(UpdateExpenseCommandMapper.billingTransactionServiceToUpdateBillingServiceDto(updatedBillingServices));
            }
        }

        private async Task ArchiveBillingTransactionServices
            (UpdateExpenseResultDto updateExpenseResultDto,
            List<UpdateBillingServiceDto> billingServicesToArchive,
            CancellationToken cancellationToken)
        {
            if (billingServicesToArchive.Any())
            {
                var bSTA = UpdateExpenseCommandMapper
                    .UpdateBillingServiceDtoToBillingTransactionService(billingServicesToArchive, updateExpenseResultDto.Id);
                await _billingTransactionServiceRepository.DeleteManyAsync(bSTA, cancellationToken);
            }
        }
    }
}
