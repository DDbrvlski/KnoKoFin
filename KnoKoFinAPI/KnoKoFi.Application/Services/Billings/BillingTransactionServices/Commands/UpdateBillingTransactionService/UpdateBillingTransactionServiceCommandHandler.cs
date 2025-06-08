using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Billings.BillingTransactionServices.Dtos;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dto;
using KnoKoFin.Domain.Interfaces.Repositories.Billings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingTransactionServices.Commands.UpdateBillingTransactionService
{
    public class UpdateBillingTransactionServiceCommandHandler : IRequestHandler<UpdateBillingTransactionServiceCommand, UpdateBillingTransactionServiceResultDto>
    {
        private readonly IBillingTransactionServiceRepository _billingServiceRepository;
        public UpdateBillingTransactionServiceCommandHandler(IBillingTransactionServiceRepository billingServiceRepository)
        {
            _billingServiceRepository = billingServiceRepository;
        }
        public async Task<UpdateBillingTransactionServiceResultDto> Handle(UpdateBillingTransactionServiceCommand request, CancellationToken cancellationToken)
        {
            var oldEntity = await _billingServiceRepository.GetByIdAsync(request.Id, cancellationToken);
            if (oldEntity == null)
            {
                throw new NotFoundException("Wystąpił błąd - nie znaleziono wybranego serwisu.");
            }

            UpdateBillingTransactionServiceCommandMapper.ApplyUpdate(oldEntity, request);

            var newEntity = await _billingServiceRepository.UpdateAsync(oldEntity, cancellationToken);
            return UpdateBillingTransactionServiceCommandMapper.BillingServiceToUpdateResultDto(newEntity);
        }
    }
}
