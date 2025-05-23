using KnoKoFin.Application.Services.Dictionaries.Contractors.Dto;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Interfaces;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Queries.GetContractorList
{
    public class GetContractorListQueryHandler : IRequestHandler<GetContractorListQuery, ContractorList>
    {
        private readonly IGetContractorListRepository _contractorRepository;
        public GetContractorListQueryHandler(IGetContractorListRepository contractorRepository)
        {
            _contractorRepository = contractorRepository;
        }

        public async Task<ContractorList> Handle(GetContractorListQuery request, CancellationToken cancellationToken)
        {
            return await _contractorRepository.GetContractorList(cancellationToken);
        }
    }
}
