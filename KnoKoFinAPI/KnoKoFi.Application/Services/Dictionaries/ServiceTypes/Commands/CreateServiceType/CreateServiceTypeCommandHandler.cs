using KnoKoFin.Application.Common.Interfaces.Dictionaries.ServiceTypes;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dto;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.CreateServiceType
{
    public class CreateServiceTypeCommandHandler : IRequestHandler<CreateServiceTypeCommand, CreateServiceTypeResultDto>
    {
        private readonly ILogger<CreateServiceTypeCommandHandler> _logger;
        private readonly IServiceTypeRepository _serviceTypeRepository;
        public CreateServiceTypeCommandHandler
            (ILogger<CreateServiceTypeCommandHandler> logger,
            IServiceTypeRepository serviceTypeRepository)
        {
            _logger = logger;
            _serviceTypeRepository = serviceTypeRepository;
        }
        public async Task<CreateServiceTypeResultDto> Handle(CreateServiceTypeCommand request, CancellationToken cancellationToken)
        {
            var serviceTypeToAdd = CreateServiceTypeCommandMapper.CommandToServiceType(request);
            var serviceType = await _serviceTypeRepository.CreateAsync(serviceTypeToAdd, cancellationToken);
            return CreateServiceTypeCommandMapper.ServiceTypeToServiceTypeDto(serviceType);
        }
    }
}
