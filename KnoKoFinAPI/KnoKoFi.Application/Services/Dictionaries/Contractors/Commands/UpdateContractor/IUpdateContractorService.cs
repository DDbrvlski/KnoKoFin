using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress;
using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.UpdateContractor
{
    public interface IUpdateContractorService
    {
        Task<Contractor> UpdateContractorAsync(Contractor contractorToUpdate, UpdateContractorCommand updateContractorCommand, Address address, CancellationToken cancellationToken);
        Task<Address?> UpdateOrCreateAddressAsync(Contractor contractorToUpdate, UpdateAddressCommand? addressCommand, CancellationToken cancellationToken);
        Task<Contractor> GetContractorById(long id);
    }
}