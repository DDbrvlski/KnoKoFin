using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Dictionaries.Services.Dto;
using KnoKoFin.Application.Services.Dictionaries.Services.Interfaces;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Services.Queries.GetServiceDetails
{
    public class GetServiceDetailsQueryHandler : IRequestHandler<GetServiceDetailsQuery, ServiceDetailsDto>
    {
        private readonly IGetServiceDetailsRepository _serviceRepository;
        public GetServiceDetailsQueryHandler(IGetServiceDetailsRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<ServiceDetailsDto> Handle(GetServiceDetailsQuery request, CancellationToken cancellationToken)
        {
            var serviceDetailsDto = await _serviceRepository.GetServiceDetailsAsync(request.Id, cancellationToken);
            if (serviceDetailsDto == null) 
            {
                throw new NotFoundException($"Nie znaleziono serwisu o id {request.Id}");
            }
            return serviceDetailsDto;
        }
    }
}
