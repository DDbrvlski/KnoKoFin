﻿using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Entities.Invoices;
using Microsoft.EntityFrameworkCore;

namespace KnoKoFin.Infrastructure.Persistence
{
    public interface IKnoKoFinContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<Domain.Entities.Billings.Service> BillingServices { get; set; }
        DbSet<Domain.Entities.Dictionaries.Contractor> DictionaryContractors { get; set; }
        DbSet<Domain.Entities.Dictionaries.Service> DictionaryServices { get; set; }
        DbSet<ExpensePosition> ExpensePositions { get; set; }
        DbSet<Expense> Expenses { get; set; }
        DbSet<Domain.Entities.Invoices.Contractor> InvoiceContractors { get; set; }
        DbSet<InvoiceMetadata> InvoiceMetadata { get; set; }
        DbSet<Invoice> Invoices { get; set; }
        DbSet<RevenuePosition> RevenuePositions { get; set; }
        DbSet<Revenue> Revenues { get; set; }
        DbSet<ServiceType> ServiceTypes { get; set; }
        DbSet<TransactionType> TransactionTypes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}