using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Common.Interfaces.Dictionaries.Addresses;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, UpdateAddressCommand>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger<UpdateAddressCommandHandler> _logger;
        public UpdateAddressCommandHandler
            (IAddressRepository addressRepository,
            ILogger<UpdateAddressCommandHandler> logger)
        {
            _addressRepository = addressRepository;
            _logger = logger;
        }

        public async Task<UpdateAddressCommand> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            //Pobieranie encji do modyfikacji
            var entity = await _addressRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity != null)
            {
                //Mapowanie pól z obiektu UpdateAddressCommand - request do obiektu Address entity
                var newAddress = UpdateAddressCommandMapper.ApplyUpdate(entity, request);
                //Aktualizacja zmapowanego obiektu
                var updatedAddress = await _addressRepository.UpdateAsync(newAddress, cancellationToken);

                _logger.LogInformation("Adres został pomyślnie zmodyfikowany: {Id}", entity.Id);
                //Zwrot zaktualizowanego obiektu encji
                return UpdateAddressCommandMapper.AddressToAddressCommand(updatedAddress);
            }
            else
            {
                throw new NotFoundException(nameof(Address), request.Id);
            }
        }
    }
}
