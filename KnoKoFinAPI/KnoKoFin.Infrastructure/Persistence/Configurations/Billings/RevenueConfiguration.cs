using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Infrastructure.Persistence.Configurations.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Billings
{
    public class RevenueConfiguration : BaseModelConfiguration<Revenue>, IEntityTypeConfiguration<Revenue>
    {
        public void Configure(EntityTypeBuilder<Revenue> builder)
        {
            builder.ToTable("revenues", "billing");

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("NAME");

            builder.Property(r => r.Description)
                .HasMaxLength(500)
                .HasColumnName("DESCRIPTION");

            builder.Property(r => r.SaleDate)
                .IsRequired()
                .HasColumnName("SALE_DATE");

            builder.Property(r => r.TotalNetPrice)
                .HasColumnType("decimal(10,2)")
                .HasColumnName("TOTAL_NET_PRICE");

            builder.Property(r => r.TotalGrossPrice)
                .HasColumnType("decimal(10,2)")
                .HasColumnName("TOTAL_GROSS_PRICE");

            builder.Property(r => r.CategoryId)
                .HasColumnName("CATEGORY_ID")
                .IsRequired();

            builder.Property(r => r.InvoiceId)
                .HasColumnName("INVOICE_ID");

            builder.Property(r => r.ContractorId)
                .HasColumnName("CONTRACTOR_ID");

            builder.HasOne(r => r.Category)
                .WithMany()
                .HasForeignKey(r => r.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Invoice)
                .WithMany()
                .HasForeignKey(r => r.InvoiceId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(r => r.Contractor)
                .WithMany()
                .HasForeignKey(r => r.ContractorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(r => r.Positions)
                .WithOne()
                .HasForeignKey("RevenueId");
        }
    }
}
