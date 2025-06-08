using KnoKoFin.Application.Services.Billings.Expenses.Commands.CreateExpense;
using KnoKoFin.Application.Services.Billings.Expenses.Commands.DeleteExpense;
using KnoKoFin.Application.Services.Billings.Revenues.Commands.CreateRevenue;
using KnoKoFin.Application.Services.Billings.Revenues.Commands.DeleteRevenue;
using KnoKoFin.Application.Services.Billings.Revenues.Interfaces;
using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Interfaces.Repositories.Billings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Revenues
{
    public class RevenueAppService : IRevenueAppService
    {
        private readonly IRevenueRepository _revenueRepository;
        private readonly IBillingTransactionServiceRepository _billingTransactionServiceRepository;
        public RevenueAppService(IRevenueRepository revenueRepository, IBillingTransactionServiceRepository billingTransactionServiceRepository)
        {
            _revenueRepository = revenueRepository;
            _billingTransactionServiceRepository = billingTransactionServiceRepository;
        }

        public async Task<Revenue> CreateRevenueAsync(CreateRevenueCommand request, CancellationToken cancellationToken)
        {
            var revenue = CreateRevenueCommandMapper.MapCommandToRevenue(request);
            var addedRevenue = await _revenueRepository.CreateAsync(revenue, cancellationToken);

            var billingServices = CreateExpenseCommandMapper.MapCommandToBillingServiceList(request, revenue.Id);
            var addedBillingServices = await _billingTransactionServiceRepository.CreateManyAsync(billingServices, cancellationToken);

            return revenue;
        }
        public async Task ArchiveRevenueAsync(DeleteRevenueCommand request, CancellationToken cancellationToken)
        {
            var billingServicesToArchive = await _billingTransactionServiceRepository.GetBillingTransactionServiceForExpenseAsync(request.Id, cancellationToken);
            await _revenueRepository.DeleteAsync(request.Id, cancellationToken);
            await _billingTransactionServiceRepository.DeleteManyAsync(billingServicesToArchive, cancellationToken);
        }
    }
}
