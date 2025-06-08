using KnoKoFin.Application.Common.Interfaces.Dictionaries.ServiceTypes;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dtos;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.CreateServiceType
{
    public class CreateTransactionServiceTypeCommandHandler : IRequestHandler<CreateTransactionServiceTypeCommand, CreateTransactionServiceTypeResultDto>
    {
        private readonly ILogger<CreateTransactionServiceTypeCommandHandler> _logger;
        private readonly ITransactionServiceTypeRepository _serviceTypeRepository;
        public CreateTransactionServiceTypeCommandHandler
            (ILogger<CreateTransactionServiceTypeCommandHandler> logger,
            ITransactionServiceTypeRepository serviceTypeRepository)
        {
            _logger = logger;
            _serviceTypeRepository = serviceTypeRepository;
        }
        public async Task<CreateTransactionServiceTypeResultDto> Handle(CreateTransactionServiceTypeCommand request, CancellationToken cancellationToken)
        {
            var serviceTypeToAdd = CreateTransactionServiceTypeCommandMapper.CommandToServiceType(request);
            var serviceType = await _serviceTypeRepository.CreateAsync(serviceTypeToAdd, cancellationToken);
            return CreateTransactionServiceTypeCommandMapper.ServiceTypeToServiceTypeDto(serviceType);
        }
    }
}
