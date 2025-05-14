using KnoKoFin.Application.Common.Exceptions;
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
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, UpdateServiceDto>
    {
        private readonly ILogger<UpdateServiceCommandHandler> _logger;
        private readonly IDictionaryServiceRepository _serviceRepository;
        private readonly UpdateServiceCommandMapper _mapper;

        public UpdateServiceCommandHandler
            (UpdateServiceCommandMapper mapper,
            ILogger<UpdateServiceCommandHandler> logger,
            IDictionaryServiceRepository serviceRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _serviceRepository = serviceRepository;
        }
        public async Task<UpdateServiceDto> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceToUpdate = await _serviceRepository.GetByIdAsync(request.Id, cancellationToken);
            if (serviceToUpdate == null) 
            {
                throw new UpdateFailureException(nameof(serviceToUpdate), request.Id, "Nie znaleziono podanego serwisu do aktualizacji");
            }

            var service = _mapper.Map(serviceToUpdate, request);
            var updatedService = await _serviceRepository.UpdateAsync(service, cancellationToken);

            return _mapper.Map(updatedService);
        }
    }
}
