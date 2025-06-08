using KnoKoFin.Application.Services.Billings.BillingTransactionServices.Dtos;
using KnoKoFin.Application.Services.Billings.BillingTransactionServices.Interfaces;
using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Interfaces.Repositories.Billings;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Infrastructure.Repositories.Billings
{
    public class BillingServiceRepository : 
        GenericRepository<BillingTransactionService>, 
        IBillingTransactionServiceRepository,
        IGetBillingTransactionServiceDetailsQueryRepository,
        IGetBillingTransactionServiceListQueryRepository
    {
        public BillingServiceRepository(KnoKoFinContext context, ILogger<GenericRepository<BillingTransactionService>> logger) : base(context, logger)
        {
        }

        public async Task<List<BillingTransactionService>> GetBillingTransactionServiceForExpenseAsync(long expenseId, CancellationToken cancellationToken)
        {
            var entities = await GetAll()
                .Where(x => x.ExpensesId == expenseId)
                .ToListAsync();

            return entities;
        }

        public async Task<BillingTransactionServiceDetailsDto> GetBillingTransactionServiceDetailsAsync(long id, CancellationToken cancellationToken)
        {
            var entity = await GetSingle(id)
                .Select(x => new BillingTransactionServiceDetailsDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Discount = x.Discount,
                    CreatedAt = x.CreatedAt,
                    GrossPrice = x.GrossPrice,
                    NetPrice = x.NetPrice,
                    Quantity = x.Quantity,
                    RowVersion = x.RowVersion,
                    ServiceTypeId = x.ServiceTypeId,
                    ServiceTypeName = x.ServiceType.Name,
                    LastModifiedAt = x.UpdatedAt,
                    Unit = x.Unit.ToString(),
                    Vat = x.Vat
                }).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<BillingTransactionServiceListDto> GetBillingTransactionServiceListAsync(CancellationToken cancellationToken)
        {
            var items = await GetAll()
                .Select(x => new BillingTransactionServiceDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ServiceTypeName = x.ServiceType.Name
                }).ToListAsync(cancellationToken);

            return new BillingTransactionServiceListDto() { BillingServices = items };
        }
    }
}
