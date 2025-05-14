using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Queries.GetContractorDetails
{
    public class GetContractorDetailsQuery : IRequest<ContractorDetailsDto>
    {
        public long Id { get; set; }
    }
}
