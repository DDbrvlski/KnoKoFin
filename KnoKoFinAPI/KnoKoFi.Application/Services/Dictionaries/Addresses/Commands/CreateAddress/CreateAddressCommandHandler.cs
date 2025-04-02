using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Infrastructure.Persistence;
using KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries;
using KnoKoFin.Infrastructure.Repositories.Dictionaries.Addresses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreateAddressCommand>
    {
        private readonly IAddressRepository _repository;
        private readonly CreateAddressMapper _mapper;
        private readonly ILogger<CreateAddressCommandHandler> _logger;

        public CreateAddressCommandHandler
            (IAddressRepository repository, 
            CreateAddressMapper mapper, 
            ILogger<CreateAddressCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreateAddressCommand> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.CreateAddressCommandToAddressMap(request);

            await _repository.CreateAsync(entity, cancellationToken);

            _logger.LogInformation($"Adres został pomyślnie utworzony: {0}", entity.Id);
            return _mapper.AddressToCreateAddressCommandMap(entity);    
        }

    }
}
