using KnoKoFin.Domain.Entities.Dictionaries;
using Microsoft.EntityFrameworkCore;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Queries.GetContractorList
{
    public static class GetContractorListQueryMapper
    {
        public static async Task<ContractorList> GetContractorList(IQueryable<DictionaryContractor> query, CancellationToken cancellationToken)
        {
            var items = await query.Select(x => new ContractorDto()
            {
                Id = x.Id,
                Name = x.Name,
                ContractorType = x.ContractorType,
                FullName = $"{x.FirstName} {x.LastName}"
            }).ToListAsync(cancellationToken);

            return new ContractorList() { Contractors = items };
        }
    }
}
