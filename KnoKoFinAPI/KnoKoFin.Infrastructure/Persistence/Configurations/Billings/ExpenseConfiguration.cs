using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Enums;
using KnoKoFin.Infrastructure.Persistence.Configurations.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Billings
{
    public class ExpenseConfiguration : BaseModelConfiguration<Expense>, IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("expenses", "billing");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("NAME");

            builder.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("DESCRIPTION");

            builder.Property(e => e.PurchaseDate)
                .IsRequired()
                .HasColumnName("PURCHASE_DATE");

            builder.Property(e => e.TotalNetPrice)
                .HasColumnType("decimal(10,2)")
                .HasColumnName("TOTAL_NET_PRICE");

            builder.Property(e => e.TotalGrossPrice)
                .HasColumnType("decimal(10,2)")
                .HasColumnName("TOTAL_GROSS_PRICE");

            builder.Property(e => e.TransactionTypeId)
                .HasColumnName("TRANSACTION_TYPE_ID");

            builder.HasOne(e => e.TransactionType)
                .WithMany()
                .HasForeignKey(e => e.TransactionTypeId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(e => e.ContractorId)
                .HasColumnName("CONTRACTOR_ID");

            builder.HasOne(e => e.Contractor)
                .WithMany()
                .HasForeignKey(e => e.ContractorId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
