
using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Common.Interfaces.Dictionaries.Addresses;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Queries.GetAddressDetails
{
    public class GetAddressDetailsQueryHandler : IRequestHandler<GetAddressDetailsQuery, AddressDetailsDto>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger<GetAddressDetailsQueryHandler> _logger;
        public GetAddressDetailsQueryHandler
            (IAddressRepository addressRepository,
            ILogger<GetAddressDetailsQueryHandler> logger)
        {
            _addressRepository = addressRepository;
            _logger = logger;
        }
        public async Task<AddressDetailsDto> Handle(GetAddressDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _addressRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity != null)
            {
                return GetAddressDetailsQueryMapper.Map(entity);
            }
            else
            {
                throw new NotFoundException(nameof(Address), request.Id);
            }
        }
    }
}
