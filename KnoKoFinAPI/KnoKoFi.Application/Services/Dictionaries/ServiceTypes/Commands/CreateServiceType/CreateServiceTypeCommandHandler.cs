using KnoKoFin.Application.Common.Interfaces.Dictionaries.ServiceTypes;
using KnoKoFin.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.CreateServiceType
{
    public class CreateServiceTypeCommandHandler : IRequestHandler<CreateServiceTypeCommand, CreateServiceTypeDto>
    {
        private readonly ILogger<CreateServiceTypeCommandHandler> _logger;
        private readonly IServiceTypeRepository _serviceTypeRepository;
        private readonly ICreateServiceTypeCommandMapper _mapper;
        public CreateServiceTypeCommandHandler
            (ILogger<CreateServiceTypeCommandHandler> logger,
            IServiceTypeRepository serviceTypeRepository,
            ICreateServiceTypeCommandMapper mapper)
        {
            _logger = logger;
            _serviceTypeRepository = serviceTypeRepository;
            _mapper = mapper;
        }
        public async Task<CreateServiceTypeDto> Handle(CreateServiceTypeCommand request, CancellationToken cancellationToken)
        {
            var serviceTypeToAdd = _mapper.Map(request);
            var serviceType = await _serviceTypeRepository.CreateAsync(serviceTypeToAdd, cancellationToken);
            return _mapper.Map(serviceType);
        }
    }
}
