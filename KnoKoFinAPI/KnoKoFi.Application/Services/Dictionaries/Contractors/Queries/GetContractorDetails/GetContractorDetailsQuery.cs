using KnoKoFin.Application.DTOs;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Dtos;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Queries.GetContractorDetails
{
    public class GetContractorDetailsQuery : BaseDto, IRequest<ContractorDetailsDto>
    {
        public long Id { get; set; }
    }
}
