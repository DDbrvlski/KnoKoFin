using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Entities.Invoices;
using Microsoft.EntityFrameworkCore;

namespace KnoKoFin.Infrastructure.Persistence
{
    public interface IKnoKoFinContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<BillingTransactionService> BillingServices { get; set; }
        DbSet<DictionaryContractor> DictionaryContractors { get; set; }
        DbSet<DictionaryTransactionService> DictionaryServices { get; set; }
        DbSet<ExpensePosition> ExpensePositions { get; set; }
        DbSet<Expense> Expenses { get; set; }
        DbSet<InvoiceContractor> InvoiceContractors { get; set; }
        DbSet<InvoiceMetadata> InvoiceMetadata { get; set; }
        DbSet<Invoice> Invoices { get; set; }
        DbSet<RevenuePosition> RevenuePositions { get; set; }
        DbSet<Revenue> Revenues { get; set; }
        DbSet<TransactionServiceType> ServiceTypes { get; set; }
        DbSet<TransactionType> TransactionTypes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}