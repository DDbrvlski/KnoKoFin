using KnoKoFin.Domain.Interfaces.Repositories.Billings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingServices.Commands.CreateBillingService
{
    public class CreateBillingServiceCommandHandler : IRequestHandler<CreateBillingServiceCommand, long>
    {
        private readonly IBillingServiceRepository _billingService;
        public CreateBillingServiceCommandHandler(IBillingServiceRepository billingService)
        {
            _billingService = billingService;
        }

        public async Task<long> Handle(CreateBillingServiceCommand request, CancellationToken cancellationToken)
        {
            var newBillingService = CreateBillingServiceCommandMapper.MapCommandToBillingService(request, cancellationToken);
            var item = await _billingService.CreateAsync(newBillingService, cancellationToken);

            return item.Id;
        }
    }
}
