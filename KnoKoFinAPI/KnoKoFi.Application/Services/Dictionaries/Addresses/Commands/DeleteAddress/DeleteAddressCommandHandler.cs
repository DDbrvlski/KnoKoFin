using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.DeleteAddress
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger<DeleteAddressCommandHandler> _logger;
        public DeleteAddressCommandHandler
            (IAddressRepository repository,
            ILogger<DeleteAddressCommandHandler> logger)
        {
            _addressRepository = repository;
            _logger = logger;
        }
        public async Task Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            await _addressRepository.DeleteAsync(request.Id, cancellationToken);
            _logger.LogInformation($"Adres został pomyślnie usunięty: {0}", request.Id);
        }
    }
}
