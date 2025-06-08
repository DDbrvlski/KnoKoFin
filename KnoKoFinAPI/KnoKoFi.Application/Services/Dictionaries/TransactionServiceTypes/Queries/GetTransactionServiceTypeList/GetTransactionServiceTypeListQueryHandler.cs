using KnoKoFin.Application.Services.Dictionaries.TransactionServiceTypes.Dtos;
using KnoKoFin.Application.Services.Dictionaries.TransactionServiceTypes.Interfaces;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServiceTypes.Queries.GetTransactionServiceTypeList
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
