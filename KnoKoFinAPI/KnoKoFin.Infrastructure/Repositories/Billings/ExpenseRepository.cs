using KnoKoFin.Application.Services.Billings.Expenses.Dtos;
using KnoKoFin.Application.Services.Billings.Expenses.Interfaces;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Dtos;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Dtos;
using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Interfaces.Repositories.Billings;
using KnoKoFin.Infrastructure.Common.Exceptions;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data.Entity;
using System.Linq.Expressions;

namespace KnoKoFin.Infrastructure.Repositories.Billings
{
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository, IGetExpenseListQueryRepository, IGetExpenseDetailsQueryRepository
    {
        private readonly ILogger<ExpenseRepository> _repositoryLogger;
        public ExpenseRepository(KnoKoFinContext context, ILogger<GenericRepository<Expense>> logger, ILogger<ExpenseRepository> repositoryLogger) : base(context, logger)
        {
            _repositoryLogger = repositoryLogger;
        }

        
        public async Task<ExpenseDetailsDto> GetExpenseDetailsAsync(long id, CancellationToken cancellationToken)
        {
            var item = await GetSingle(id)
                .Select(ExpenseProjection)
                .FirstOrDefaultAsync(x => x.Id == id);

            return item;
        }

        public async Task<ExpenseListDto> GetExpenseListAsync(CancellationToken cancellationToken)
        {
            var items = await GetAll()
                .Select(x => new ExpenseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    PurchaseDate = x.PurchaseDate,
                    TotalGrossPrice = x.TotalGrossPrice,
                    ContractorName = x.Contractor.Name ?? $"{x.Contractor.FirstName} {x.Contractor.LastName}",
                    TransactionTypeName = x.TransactionType.Name
                }).ToListAsync();

            return new ExpenseListDto { ExpenseItems = items };
        }

        private static Expression<Func<Expense, ExpenseDetailsDto>> ExpenseProjection =>
            x => new ExpenseDetailsDto
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            PurchaseDate = x.PurchaseDate,
            TotalGrossPrice = x.TotalGrossPrice,
            TotalNetPrice = x.TotalNetPrice,
            TransactionTypeName = x.TransactionType.Name,
            ContractorDetails = new ContractorDetailsDto
            {
                Id = x.Contractor.Id,
                FirstName = x.Contractor.FirstName,
                LastName = x.Contractor.LastName,
                BankAccountNumber = x.Contractor.BankAccountNumber,
                BankName = x.Contractor.BankName,
                ContractorType = x.Contractor.ContractorType.ToString(),
                Email = x.Contractor.Email,
                Description = x.Contractor.Description,
                Fax = x.Contractor.Fax,
                Name = x.Contractor.Name,
                Nip = x.Contractor.Nip,
                PhoneNumber = x.Contractor.PhoneNumber,
                Swift = x.Contractor.Swift,
                CreatedAt = x.Contractor.CreatedAt,
                LastModifiedAt = x.Contractor.UpdatedAt,
                RowVersion = x.Contractor.RowVersion,
                Address = x.Contractor.Address == null ? null : new AddressDetailsDto
                {
                    Id = x.Contractor.Address.Id,
                    City = x.Contractor.Address.City,
                    Country = x.Contractor.Address.Country,
                    Street = x.Contractor.Address.Street,
                    Postcode = x.Contractor.Address.PostCode,
                    CreatedAt = x.Contractor.Address.CreatedAt,
                    LastModifiedAt = x.Contractor.Address.UpdatedAt,
                    RowVersion = x.Contractor.Address.RowVersion
                }
            },
            BillingServiceDetailsList = x.BillingTransactionService
                .Select(z => new BillingServiceDetailsDto()
                {
                    Id = z.Id,
                    Description = z.Description,
                    Discount = z.Discount,
                    GrossPrice = z.GrossPrice,
                    NetPrice = z.NetPrice,
                    Name = z.Name,
                    Quantity = z.Quantity,
                    ServiceTypeId = z.ServiceTypeId,
                    ServiceTypeName = z.ServiceType.Name,
                    Unit = z.Unit.ToString(),
                    Vat = z.Vat
                }).ToList()
            
        };

    }
}
