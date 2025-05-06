using KnoKoFin.Domain.Entities.Invoices;
using KnoKoFin.Infrastructure.Persistence.Configurations.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Invoices
{
    public class InvoiceConfiguration : BaseModelConfiguration<Invoice>, IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoices", "invoices");

            builder.Property(i => i.InvoiceMetadataId)
                .HasColumnName("INVOICE_METADATA_ID");

            builder.Property(i => i.InternalInvoiceContractorId)
                .HasColumnName("INTERNAL_INVOICE_CONTRACTOR_ID");

            builder.Property(i => i.ExternalInvoiceContractorId)
                .HasColumnName("EXTERNAL_INVOICE_CONTRACTOR_ID");

            builder.Property(i => i.RevenueId)
                .HasColumnName("REVENUE");

            builder.HasOne(i => i.Metadata)
                .WithMany()
                .HasForeignKey(i => i.InvoiceMetadataId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.InternalContractor)
                .WithMany()
                .HasForeignKey(i => i.InternalInvoiceContractorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.ExternalContractor)
                .WithMany()
                .HasForeignKey(i => i.ExternalInvoiceContractorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Revenue)
                .WithOne()
                .HasForeignKey<Invoice>(i => i.RevenueId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
