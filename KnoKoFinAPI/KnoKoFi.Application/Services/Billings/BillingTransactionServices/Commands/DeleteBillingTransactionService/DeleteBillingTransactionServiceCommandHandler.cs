using KnoKoFin.Domain.Interfaces.Repositories.Billings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingServices.Commands.DeleteBillingService
{
    public class DeleteBillingTransactionServiceCommandHandler : IRequestHandler<DeleteBillingTransactionServiceCommand>
    {
        private readonly IBillingServiceRepository _billingServiceRepository;
        public DeleteBillingTransactionServiceCommandHandler(IBillingServiceRepository billingServiceRepository)
        {
            _billingServiceRepository = billingServiceRepository;
        }

        public async Task Handle(DeleteBillingTransactionServiceCommand request, CancellationToken cancellationToken)
        {
            await _billingServiceRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
