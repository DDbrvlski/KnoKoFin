using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Common.Interfaces.Dictionaries.Addresses;
using KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries;
using KnoKoFin.Infrastructure.Repositories.Dictionaries.Addresses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, UpdateAddressCommand>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger<UpdateAddressCommandHandler> _logger;
        private readonly IUpdateAddressMapper _mapper;
        public UpdateAddressCommandHandler
            (IAddressRepository addressRepository, 
            ILogger<UpdateAddressCommandHandler> logger,
            IUpdateAddressMapper mapper)
        {
            _addressRepository = addressRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<UpdateAddressCommand> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            //Pobieranie encji do modyfikacji
            var entity = await _addressRepository.GetByIdAsync(request.Id);
            if (entity != null)
            {
                //Mapowanie pól z obiektu UpdateAddressCommand - request do obiektu Address entity
                var newAddress = _mapper.Map(entity, request);
                //Aktualizacja zmapowanego obiektu
                var updatedAddress = await _addressRepository.UpdateAsync(newAddress, cancellationToken);

                _logger.LogInformation("Adres został pomyślnie zmodyfikowany: {Id}", entity.Id);
                //Zwrot zaktualizowanego obiektu encji
                return _mapper.Map(updatedAddress);
            }
            else
            {
                throw new NotFoundException(nameof(Address), request.Id);
            }
        }
    }
}
