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
    public class DeleteTransactionServiceCommandHandler : IRequestHandler<DeleteTransactionServiceCommand>
    {
        private readonly ILogger<DeleteTransactionServiceCommandHandler> _logger;
        private readonly IDictionaryTransactionServiceRepository _serviceRepository;

        public DeleteTransactionServiceCommandHandler
            (ILogger<DeleteTransactionServiceCommandHandler> logger,
            IDictionaryTransactionServiceRepository serviceRepository)
        {
            _logger = logger;
            _serviceRepository = serviceRepository;
        }
        public async Task Handle(DeleteTransactionServiceCommand request, CancellationToken cancellationToken)
        {
            await _serviceRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
