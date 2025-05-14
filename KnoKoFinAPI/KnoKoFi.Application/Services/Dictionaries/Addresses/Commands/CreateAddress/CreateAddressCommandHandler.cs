using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreateAddressCommand>
    {
        private readonly IAddressRepository _repository;
        private readonly ILogger<CreateAddressCommandHandler> _logger;

        public CreateAddressCommandHandler
            (IAddressRepository repository,
            ILogger<CreateAddressCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<CreateAddressCommand> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = CreateAddressMapper.CreateAddressCommandToAddressMap(request);

            await _repository.CreateAsync(entity, cancellationToken);

            _logger.LogInformation($"Adres został pomyślnie utworzony: {0}", entity.Id);
            return CreateAddressMapper.AddressToCreateAddressCommandMap(entity);
        }

    }
}
