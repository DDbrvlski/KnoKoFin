using KnoKoFin.Database.Models.Billings;
using KnoKoFin.Database.Models.Dictionaries;
using KnoKoFin.Database.Models.Helpers;
using KnoKoFin.Database.Models.Invoices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Database.Context
{
    public class KnoKoFinContext : DbContext
    {
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<RevenuePosition> RevenuePositions { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpensePosition> ExpensePositions { get; set; }
        public DbSet<Models.Billings.Service> BillingServices { get; set; }
        public DbSet<Models.Dictionaries.Service> DictionaryServices { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceMetadata> InvoiceMetadata { get; set; }
        public DbSet<Models.Dictionaries.Contractor> DictionaryContractors { get; set; }
        public DbSet<Models.Invoices.Contractor> InvoiceContractors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }

    }
}
