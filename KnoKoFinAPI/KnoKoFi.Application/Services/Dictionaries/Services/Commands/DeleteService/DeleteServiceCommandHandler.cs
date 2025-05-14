using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Services.Commands.DeleteService
{
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
    {
        private readonly ILogger<DeleteServiceCommandHandler> _logger;
        private readonly IDictionaryServiceRepository _serviceRepository;

        public DeleteServiceCommandHandler
            (ILogger<DeleteServiceCommandHandler> logger,
            IDictionaryServiceRepository serviceRepository)
        {
            _logger = logger;
            _serviceRepository = serviceRepository;
        }
        public async Task Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            await _serviceRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
