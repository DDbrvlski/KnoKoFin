using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Dictionaries.Services.Dtos;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Services.Commands.UpdateService
{
    public class UpdateTransactionServiceCommandHandler : IRequestHandler<UpdateTransactionServiceCommand, UpdateServiceResultDto>
    {
        private readonly ILogger<UpdateTransactionServiceCommandHandler> _logger;
        private readonly IDictionaryTransactionServiceRepository _serviceRepository;

        public UpdateTransactionServiceCommandHandler
            (ILogger<UpdateTransactionServiceCommandHandler> logger,
            IDictionaryTransactionServiceRepository serviceRepository)
        {
            _logger = logger;
            _serviceRepository = serviceRepository;
        }
        public async Task<UpdateServiceResultDto> Handle(UpdateTransactionServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceToUpdate = await _serviceRepository.GetByIdAsync(request.Id, cancellationToken);
            if (serviceToUpdate == null) 
            {
                throw new UpdateFailureException(nameof(serviceToUpdate), request.Id, "Nie znaleziono podanego serwisu do aktualizacji");
            }

            var service = UpdateTransactionServiceCommandMapper.ApplyUpdate(serviceToUpdate, request);
            var updatedService = await _serviceRepository.UpdateAsync(service, cancellationToken);

            return UpdateTransactionServiceCommandMapper.ServiceToUpdateServiceDto(updatedService);
        }
    }
}
