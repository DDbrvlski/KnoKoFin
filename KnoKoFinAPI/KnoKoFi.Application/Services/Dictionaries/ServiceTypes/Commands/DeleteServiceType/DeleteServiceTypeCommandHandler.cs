using KnoKoFin.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.DeleteServiceType
{
    public class DeleteServiceTypeCommandHandler : IRequestHandler<DeleteServiceTypeCommand>
    {
        private readonly ILogger<DeleteServiceTypeCommandHandler> _logger;
        private readonly IServiceTypeRepository _serviceTypeRepository;

        public DeleteServiceTypeCommandHandler
            (ILogger<DeleteServiceTypeCommandHandler> logger,
            IServiceTypeRepository serviceTypeRepository)
        {
            _logger = logger;
            _serviceTypeRepository = serviceTypeRepository;
        }

        public async Task Handle(DeleteServiceTypeCommand request, CancellationToken cancellationToken)
        {
            await _serviceTypeRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
