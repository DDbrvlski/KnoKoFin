using KnoKoFin.Infrastructure.Persistence.Configurations.Billings;
using KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries;
using KnoKoFin.Infrastructure.Persistence.Configurations.Invoices;
using Microsoft.EntityFrameworkCore;

namespace KnoKoFin.Infrastructure.Persistence
{
    public interface IKnoKoFinContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<Configurations.Billings.Service> BillingServices { get; set; }
        DbSet<Configurations.Dictionaries.Contractor> DictionaryContractors { get; set; }
        DbSet<Configurations.Dictionaries.Service> DictionaryServices { get; set; }
        DbSet<ExpensePosition> ExpensePositions { get; set; }
        DbSet<Expense> Expenses { get; set; }
        DbSet<Configurations.Invoices.Contractor> InvoiceContractors { get; set; }
        DbSet<InvoiceMetadata> InvoiceMetadata { get; set; }
        DbSet<Invoice> Invoices { get; set; }
        DbSet<RevenuePosition> RevenuePositions { get; set; }
        DbSet<Revenue> Revenues { get; set; }
        DbSet<ServiceType> ServiceTypes { get; set; }
        DbSet<TransactionType> TransactionTypes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}