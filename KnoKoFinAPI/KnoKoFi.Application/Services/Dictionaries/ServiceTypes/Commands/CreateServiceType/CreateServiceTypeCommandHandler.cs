using KnoKoFin.Application.Common.Interfaces.Dictionaries.ServiceTypes;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.CreateServiceType
{
    public class CreateServiceTypeCommandHandler : IRequestHandler<CreateServiceTypeCommand, CreateServiceTypeDto>
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
        public async Task<CreateServiceTypeDto> Handle(CreateServiceTypeCommand request, CancellationToken cancellationToken)
        {
            var serviceTypeToAdd = CreateServiceTypeCommandMapper.Map(request);
            var serviceType = await _serviceTypeRepository.CreateAsync(serviceTypeToAdd, cancellationToken);
            return CreateServiceTypeCommandMapper.Map(serviceType);
        }
    }
}
