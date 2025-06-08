using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Infrastructure.Persistence.Configurations.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Billings
{
    public class TransactionServiceConfiguration : BaseModelConfiguration<BillingTransactionService>, IEntityTypeConfiguration<BillingTransactionService>
    {
        public void Configure(EntityTypeBuilder<BillingTransactionService> builder)
        {
            builder.ToTable("transaction_services", "billing");

            builder.Property(s => s.Name)
                .HasMaxLength(255)
                .HasColumnName("NAME");

            builder.Property(s => s.Description)
                .HasMaxLength(255)
                .HasColumnName("DESCRIPTION");

            builder.Property(s => s.Archival)
                .IsRequired()
                .HasColumnName("ARCHIVAL");

            builder.Property(s => s.Discount)
                .HasColumnType("decimal(10,2)")
                .HasColumnName("DISCOUNT");

            builder.Property(s => s.NetPrice)
                .HasColumnType("decimal(10,2)")
                .HasColumnName("NET_PRICE");

            builder.Property(s => s.GrossPrice)
                .HasColumnType("decimal(10,2)")
                .HasColumnName("GROSS_PRICE");

            builder.Property(s => s.Vat)
                .HasColumnType("decimal(10,2)")
                .HasColumnName("VAT");

            builder.Property(s => s.Unit)
                .HasMaxLength(10)
                .HasColumnName("UNIT");

            builder.Property(s => s.Quantity)
                .HasColumnName("QUANTITY");

            builder.Property(s => s.ServiceTypeId)
                .HasColumnName("SERVICE_TYPE_ID");

            builder.HasOne(s => s.ServiceType)
                .WithMany()
                .HasForeignKey(s => s.ServiceTypeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
