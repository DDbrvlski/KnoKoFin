using KnoKoFin.Application.Services.Dictionaries.Contractors.Dto;
using KnoKoFin.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Interfaces
{
    public interface IGetContractorDetailsRepository
    {
        Task<ContractorDetailsDto> GetContractorDetails(long id, CancellationToken cancellationToken);
    }
}
