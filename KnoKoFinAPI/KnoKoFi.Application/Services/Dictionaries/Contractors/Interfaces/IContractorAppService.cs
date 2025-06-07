using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.CreateContractor;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.UpdateContractor;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Dtos;
using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Interfaces
{
    public interface IContractorAppService
    {
        Task<UpdateContractorResultDto> UpdateContractorAsync(UpdateContractorCommand command, CancellationToken cancellationToken);
        Task<DictionaryContractor> CreateContractorAsync(CreateContractorCommand command, CancellationToken cancellationToken);
    }
}