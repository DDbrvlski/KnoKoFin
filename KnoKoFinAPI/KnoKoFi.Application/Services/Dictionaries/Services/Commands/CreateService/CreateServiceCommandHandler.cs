﻿using KnoKoFin.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Services.Commands.CreateService
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, CreateServiceDto>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ILogger<CreateServiceCommandHandler> _logger;
        private readonly CreateServiceCommandMapper _mapper;

        public CreateServiceCommandHandler
            (IServiceRepository serviceRepository,
            ILogger<CreateServiceCommandHandler> logger,
            CreateServiceCommandMapper mapper)
        {
            _logger = logger;
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<CreateServiceDto> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceToAdd = _mapper.Map(request);
            var newService = await _serviceRepository.CreateAsync(serviceToAdd, cancellationToken);

            return _mapper.Map(newService);
        }
    }
}
