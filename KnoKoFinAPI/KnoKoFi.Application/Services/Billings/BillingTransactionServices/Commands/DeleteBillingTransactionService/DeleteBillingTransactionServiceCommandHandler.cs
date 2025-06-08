using KnoKoFin.Domain.Interfaces.Repositories.Billings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingTransactionServices.Commands.DeleteBillingTransactionService
{
    public class DeleteBillingTransactionServiceCommandHandler : IRequestHandler<DeleteBillingTransactionServiceCommand>
    {
        private readonly IBillingTransactionServiceRepository _billingServiceRepository;
        public DeleteBillingTransactionServiceCommandHandler(IBillingTransactionServiceRepository billingServiceRepository)
        {
            _billingServiceRepository = billingServiceRepository;
        }

        public async Task Handle(DeleteBillingTransactionServiceCommand request, CancellationToken cancellationToken)
        {
            await _billingServiceRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
