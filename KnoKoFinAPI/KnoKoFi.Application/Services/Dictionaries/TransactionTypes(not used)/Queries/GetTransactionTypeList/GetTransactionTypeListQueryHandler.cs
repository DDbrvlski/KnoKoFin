using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionTypes.Queries.GetTransactionTypeList
{
    public class GetTransactionTypeListQueryHandler : IRequestHandler<GetTransactionTypeListQuery, TransactionTypeList>
    {
        private readonly ITransactionTypeRepository _transactionTypeRepository;
        public GetTransactionTypeListQueryHandler(ITransactionTypeRepository transactionTypeRepository)
        {
            _transactionTypeRepository = transactionTypeRepository;
        }

        public async Task<TransactionTypeList> Handle(GetTransactionTypeListQuery request, CancellationToken cancellationToken)
        {
            var query = _transactionTypeRepository.GetAll();
            return await GetTransactionTypeListQueryMapper.GetTransactionTypeList(query, cancellationToken);
        }
    }
}
