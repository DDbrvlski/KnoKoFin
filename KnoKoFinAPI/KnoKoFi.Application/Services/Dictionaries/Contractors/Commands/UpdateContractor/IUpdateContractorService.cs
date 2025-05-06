using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress;
using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.UpdateContractor
{
    public interface IUpdateContractorService
    {
        Task<DictionaryContractor> UpdateContractorAsync(DictionaryContractor contractorToUpdate, UpdateContractorCommand updateContractorCommand, Address address, CancellationToken cancellationToken);
        Task<Address?> UpdateOrCreateAddressAsync(DictionaryContractor contractorToUpdate, UpdateAddressCommand? addressCommand, CancellationToken cancellationToken);
        Task<DictionaryContractor> GetContractorById(long id);
    }
}