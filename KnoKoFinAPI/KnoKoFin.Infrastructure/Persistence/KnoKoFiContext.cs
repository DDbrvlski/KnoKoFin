
using KnoKoFin.Infrastructure.Common.Helpers;
using KnoKoFin.Infrastructure.Common.Interfaces;
using KnoKoFin.Infrastructure.Persistence.Configurations.Billings;
using KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries;
using KnoKoFin.Infrastructure.Persistence.Configurations.Invoices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Persistence
{
    public class KnoKoFinContext : DbContext, IKnoKoFinContext
    {
        private readonly IDateTime _dateTime;
        public KnoKoFinContext(IDateTime dateTime)
        {
            _dateTime = dateTime; 
        }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<RevenuePosition> RevenuePositions { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpensePosition> ExpensePositions { get; set; }
        public DbSet<Configurations.Billings.Service> BillingServices { get; set; }
        public DbSet<Configurations.Dictionaries.Service> DictionaryServices { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceMetadata> InvoiceMetadata { get; set; }
        public DbSet<Configurations.Dictionaries.Contractor> DictionaryContractors { get; set; }
        public DbSet<Configurations.Invoices.Contractor> InvoiceContractors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = _dateTime.Now;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
