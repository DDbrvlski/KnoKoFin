using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Dto;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Interfaces;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Queries.GetContractorDetails
{
    public class GetContractorDetailsQueryHandler : IRequestHandler<GetContractorDetailsQuery, ContractorDetailsDto>
    {
        private readonly IGetContractorDetailsRepository _contractorRepository;
        public GetContractorDetailsQueryHandler(IGetContractorDetailsRepository contractorRepository)
        {
            _contractorRepository = contractorRepository;
        }

        public async Task<ContractorDetailsDto> Handle(GetContractorDetailsQuery request, CancellationToken cancellationToken)
        {
            var contractor = await _contractorRepository.GetContractorDetails(request.Id, cancellationToken);
            if (contractor == null)
            {
                throw new NotFoundException($"Nie znaleziono kontrahenta o id {request.Id}");
            }
            return contractor;
        }
    }
}
