using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Domain.Interfaces.Repositories.Dictionaries
{
    public interface IDictionaryContractorRepository : IGenericRepository<DictionaryContractor>
    {
        Task<GetContractorAddressIdDto?> GetContractorAddressId(long contractorId);
    }
}
