using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Entities.Invoices;
using KnoKoFin.Domain.Helpers;
using KnoKoFin.Domain.Interfaces;
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

        public KnoKoFinContext(DbContextOptions<KnoKoFinContext> options, IDateTime dateTime)
            : base(options)
        {
            _dateTime = dateTime;
        }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<RevenuePosition> RevenuePositions { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpensePosition> ExpensePositions { get; set; }
        public DbSet<Domain.Entities.Billings.Service> BillingServices { get; set; }
        public DbSet<Domain.Entities.Dictionaries.Service> DictionaryServices { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceMetadata> InvoiceMetadata { get; set; }
        public DbSet<Domain.Entities.Dictionaries.Contractor> DictionaryContractors { get; set; }
        public DbSet<Domain.Entities.Invoices.Contractor> InvoiceContractors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KnoKoFinContext).Assembly);
        }
    }
}
