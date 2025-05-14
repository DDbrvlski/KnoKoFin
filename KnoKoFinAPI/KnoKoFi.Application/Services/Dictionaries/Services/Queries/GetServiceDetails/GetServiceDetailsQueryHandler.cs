using KnoKoFin.Application.Common.Exceptions;
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
        private readonly IDictionaryServiceRepository _serviceRepository;
        public GetServiceDetailsQueryHandler(IDictionaryServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<ServiceDetailsDto> Handle(GetServiceDetailsQuery request, CancellationToken cancellationToken)
        {
            var query = _serviceRepository.GetSingle(request.Id);
            var serviceDetailsDto = await GetServiceDetailsQueryMapper.GetServiceDetails(query, cancellationToken);
            if (serviceDetailsDto == null) 
            {
                throw new NotFoundException($"Nie znaleziono serwisu o id {request.Id}");
            }
            return serviceDetailsDto;
        }
    }
}
