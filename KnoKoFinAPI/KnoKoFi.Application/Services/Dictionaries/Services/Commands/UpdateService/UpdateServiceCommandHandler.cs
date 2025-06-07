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
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, UpdateServiceResultDto>
    {
        private readonly ILogger<UpdateServiceCommandHandler> _logger;
        private readonly IDictionaryServiceRepository _serviceRepository;

        public UpdateServiceCommandHandler
            (ILogger<UpdateServiceCommandHandler> logger,
            IDictionaryServiceRepository serviceRepository)
        {
            _logger = logger;
            _serviceRepository = serviceRepository;
        }
        public async Task<UpdateServiceResultDto> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceToUpdate = await _serviceRepository.GetByIdAsync(request.Id, cancellationToken);
            if (serviceToUpdate == null) 
            {
                throw new UpdateFailureException(nameof(serviceToUpdate), request.Id, "Nie znaleziono podanego serwisu do aktualizacji");
            }

            var service = UpdateServiceCommandMapper.ApplyUpdate(serviceToUpdate, request);
            var updatedService = await _serviceRepository.UpdateAsync(service, cancellationToken);

            return UpdateServiceCommandMapper.ServiceToUpdateServiceDto(updatedService);
        }
    }
}
