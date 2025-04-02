using KnoKoFin.Infrastructure.Repositories.Dictionaries.ServiceTypes;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.CreateServiceType
{
    public class CreateServiceTypeCommandHandler : IRequestHandler<CreateServiceTypeCommand, CreateServiceTypeDto>
    {
        private readonly ILogger<CreateServiceTypeCommandHandler> _logger;
        private readonly IServiceTypeRepository _serviceTypeRepository;
        private readonly CreateServiceTypeCommandMapper _mapper;
        public CreateServiceTypeCommandHandler
            (ILogger<CreateServiceTypeCommandHandler> logger,
            IServiceTypeRepository serviceTypeRepository,
            CreateServiceTypeCommandMapper mapper)
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
