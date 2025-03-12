
using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Common.Interfaces.Dictionaries.Addresses;
using KnoKoFin.Application.DTOs.Dictionaries.Addresses;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Queries.GetAddressList;
using KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries;
using KnoKoFin.Infrastructure.Repositories.Dictionaries.Addresses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Queries.GetAddressDetails
{
    public class GetAddressDetailsQueryHandler : IRequestHandler<GetAddressDetailsQuery, AddressDetailsDto>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IGetAddressDetailsQueryMapper _mapper;
        private readonly ILogger<GetAddressDetailsQueryHandler> _logger;
        public GetAddressDetailsQueryHandler
            (IGetAddressDetailsQueryMapper mapper,
            IAddressRepository addressRepository,
            ILogger<GetAddressDetailsQueryHandler> logger)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<AddressDetailsDto> Handle(GetAddressDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _addressRepository.GetByIdAsync(request.Id);
            if(entity != null)
            {
                return _mapper.Map(entity);
            }
            else
            {
                throw new NotFoundException(nameof(Address), request.Id);
            }
        }
    }
}
