using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Queries.GetServiceTypeList;
using KnoKoFin.Application.Services.Dictionaries.TransactionServices.Dtos;
using KnoKoFin.Application.Services.Dictionaries.TransactionServices.Interfaces;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServices.Queries.GetTransactionServiceList
{
    public class GetTransactionServiceListQueryHandler : IRequestHandler<GetTransactionServiceListQuery, TransactionServiceListDto>
    {
        private readonly IGetTransactionServiceListRepository _serviceRepository;
        public GetTransactionServiceListQueryHandler(IGetTransactionServiceListRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<TransactionServiceListDto> Handle(GetTransactionServiceListQuery request, CancellationToken cancellationToken)
        {
            return await _serviceRepository.GetTransactionServiceListAsync(cancellationToken);
        }
    }
}
