using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServices.Commands.CreateTransactionService
{
    public class CreateTransactionServiceCommandHandler : IRequestHandler<CreateTransactionServiceCommand, long>
    {
        private readonly IDictionaryTransactionServiceRepository _serviceRepository;
        private readonly ILogger<CreateTransactionServiceCommandHandler> _logger;
        private readonly CreateTransactionServiceCommandMapper _mapper;

        public CreateTransactionServiceCommandHandler
            (IDictionaryTransactionServiceRepository serviceRepository,
            ILogger<CreateTransactionServiceCommandHandler> logger,
            CreateTransactionServiceCommandMapper mapper)
        {
            _logger = logger;
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateTransactionServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceToAdd = _mapper.CommandToService(request);
            var newService = await _serviceRepository.CreateAsync(serviceToAdd, cancellationToken);

            return newService.Id;
        }
    }
}
