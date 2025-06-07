using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Billings.BillingServices.Dtos;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dto;
using KnoKoFin.Domain.Interfaces.Repositories.Billings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingServices.Commands.UpdateBillingService
{
    public class UpdateBillingServiceCommandHandler : IRequestHandler<UpdateBillingServiceCommand, UpdateBillingServiceResultDto>
    {
        private readonly IBillingServiceRepository _billingServiceRepository;
        public UpdateBillingServiceCommandHandler(IBillingServiceRepository billingServiceRepository)
        {
            _billingServiceRepository = billingServiceRepository;
        }
        public async Task<UpdateBillingServiceResultDto> Handle(UpdateBillingServiceCommand request, CancellationToken cancellationToken)
        {
            var oldEntity = await _billingServiceRepository.GetByIdAsync(request.Id, cancellationToken);
            if (oldEntity == null)
            {
                throw new NotFoundException("Wystąpił błąd - nie znaleziono wybranego serwisu.");
            }
            
            UpdateBillingServiceCommandMapper.ApplyUpdate(oldEntity, request);

            var newEntity = await _billingServiceRepository.UpdateAsync(oldEntity, cancellationToken);
            return UpdateBillingServiceCommandMapper.BillingServiceToUpdateResultDto(newEntity);
        }
    }
}
