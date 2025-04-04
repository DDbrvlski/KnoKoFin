using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Interfaces.Repositories;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.CreateAddress;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
