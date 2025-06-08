using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dtos;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Interfaces;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Queries.GetServiceTypeList
{
    public class GetTransactionServiceTypeListQueryHandler : IRequestHandler<GetTransactionServiceTypeListQuery, TransactionServiceTypeListDto>
    {
        private readonly IGetTransactionServiceTypeListRepository _serviceTypeRepository;
        public GetTransactionServiceTypeListQueryHandler(IGetTransactionServiceTypeListRepository serviceTypeRepository)
        {
            _serviceTypeRepository = serviceTypeRepository;
        }

        public async Task<TransactionServiceTypeListDto> Handle(GetTransactionServiceTypeListQuery request, CancellationToken cancellationToken)
        {
            return await _serviceTypeRepository.GetTransactionServiceTypeList(cancellationToken);
        }
    }
}
