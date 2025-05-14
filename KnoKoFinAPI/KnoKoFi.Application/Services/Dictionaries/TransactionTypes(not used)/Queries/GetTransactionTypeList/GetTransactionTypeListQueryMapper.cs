using KnoKoFin.Domain.Entities.Dictionaries;
using Microsoft.EntityFrameworkCore;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionTypes.Queries.GetTransactionTypeList
{
    public static class GetTransactionTypeListQueryMapper
    {
        public static async Task<TransactionTypeList> GetTransactionTypeList(IQueryable<TransactionType> queryToMap, CancellationToken cancellationToken)
        {
            var items = await queryToMap
                .Select(x => new TransactionTypeDto()
                {
                    Name = x.Name,
                    Type = x.Type.ToString(),
                }).ToListAsync(cancellationToken);

            return new TransactionTypeList { TransactionTypes = items };
        }
    }
}
