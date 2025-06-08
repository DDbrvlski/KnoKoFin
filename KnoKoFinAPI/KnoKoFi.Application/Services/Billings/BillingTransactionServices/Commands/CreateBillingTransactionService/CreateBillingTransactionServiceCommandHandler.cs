using KnoKoFin.Domain.Interfaces.Repositories.Billings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingTransactionServices.Commands.CreateBillingTransactionService
{
    public class CreateBillingTransactionServiceCommandHandler : IRequestHandler<CreateBillingTransactionServiceCommand, long>
    {
        private readonly IBillingTransactionServiceRepository _billingService;
        public CreateBillingTransactionServiceCommandHandler(IBillingTransactionServiceRepository billingService)
        {
            _billingService = billingService;
        }

        public async Task<long> Handle(CreateBillingTransactionServiceCommand request, CancellationToken cancellationToken)
        {
            var newBillingService = CreateBillingTransactionServiceCommandMapper.MapCommandToBillingService(request, cancellationToken);
            var item = await _billingService.CreateAsync(newBillingService, cancellationToken);

            return item.Id;
        }
    }
}
