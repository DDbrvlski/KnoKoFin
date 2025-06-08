using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Dictionaries.Services.Dtos;
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
    public class GetTransactionServiceDetailsQueryHandler : IRequestHandler<GetTransactionServiceDetailsQuery, TransactionServiceDetailsDto>
    {
        private readonly IGetTransactionServiceDetailsRepository _serviceRepository;
        public GetTransactionServiceDetailsQueryHandler(IGetTransactionServiceDetailsRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<TransactionServiceDetailsDto> Handle(GetTransactionServiceDetailsQuery request, CancellationToken cancellationToken)
        {
            var serviceDetailsDto = await _serviceRepository.GetTransactionServiceDetailsAsync(request.Id, cancellationToken);
            if (serviceDetailsDto == null) 
            {
                throw new NotFoundException($"Nie znaleziono serwisu o id {request.Id}");
            }
            return serviceDetailsDto;
        }
    }
}
