using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Domain.Interfaces.Repositories
{
    public interface IContractorRepository : IGenericRepository<DictionaryContractor>
    {
        Task<GetContractorAddressIdDto?> GetContractorAddressId(long contractorId);
    }
}
