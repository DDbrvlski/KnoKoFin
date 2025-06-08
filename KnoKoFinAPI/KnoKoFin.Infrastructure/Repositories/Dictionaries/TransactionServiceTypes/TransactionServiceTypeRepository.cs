using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dto;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dtos;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Interfaces;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries.ServiceTypes
{
    public class TransactionServiceTypeRepository : GenericRepository<TransactionServiceType>, ITransactionServiceTypeRepository, IGetTransactionServiceTypeListRepository
    {
        public TransactionServiceTypeRepository(KnoKoFinContext context, ILogger<GenericRepository<TransactionServiceType>> logger)
            : base(context, logger) { }

        public async Task<TransactionServiceTypeListDto> GetTransactionServiceTypeList(CancellationToken cancellationToken)
        {
            var items = await GetAll()
                .Select(x => new TransactionServiceTypeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                })
                .ToListAsync(cancellationToken);

            return new TransactionServiceTypeListDto() { ServiceTypes = items };
        }
    }
}
