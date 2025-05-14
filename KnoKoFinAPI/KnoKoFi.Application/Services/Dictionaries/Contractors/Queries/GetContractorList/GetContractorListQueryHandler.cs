using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Queries.GetContractorList
{
    public class GetContractorListQueryHandler : IRequestHandler<GetContractorListQuery, ContractorList>
    {
        private readonly IDictionaryContractorRepository _contractorRepository;
        public GetContractorListQueryHandler(IDictionaryContractorRepository contractorRepository)
        {
            _contractorRepository = contractorRepository;
        }

        public async Task<ContractorList> Handle(GetContractorListQuery request, CancellationToken cancellationToken)
        {
            var query = _contractorRepository.GetAll();
            return await GetContractorListQueryMapper.GetContractorList(query, cancellationToken);
        }
    }
}
