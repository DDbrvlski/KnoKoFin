using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Dto;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Interfaces;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Queries.GetAddressDetails
{
    public class GetAddressDetailsQueryHandler : IRequestHandler<GetAddressDetailsQuery, AddressDetailsDto>
    {
        private readonly IGetAddressDetailsRepository _addressRepository;
        public GetAddressDetailsQueryHandler
            (IGetAddressDetailsRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<AddressDetailsDto> Handle(GetAddressDetailsQuery request, CancellationToken cancellationToken)
        {
            var item = await _addressRepository.GetAddressDetailsAsync(request.Id, cancellationToken);
            if (item == null)
            {
                throw new NotFoundException($"Nie znaleziono adresu o podanym ID {request.Id}");
            }
            return item;
        }
    }
}
