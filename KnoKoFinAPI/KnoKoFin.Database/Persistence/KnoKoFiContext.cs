using KnoKoFin.Database.Models.Helpers;
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
    public class KnoKoFinContext : DbContext
    {
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

    }
}
