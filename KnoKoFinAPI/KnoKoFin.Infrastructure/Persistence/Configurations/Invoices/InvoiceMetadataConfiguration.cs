using KnoKoFin.Domain.Entities.Invoices;
using KnoKoFin.Infrastructure.Persistence.Configurations.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Invoices
{
    public class InvoiceMetadataConfiguration : BaseModelConfiguration<InvoiceMetadata>, IEntityTypeConfiguration<InvoiceMetadata>
    {
        public void Configure(EntityTypeBuilder<InvoiceMetadata> builder)
        {
            builder.ToTable("invoice_metadata", "invoices");

            builder.Property(im => im.InvoiceNumber)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("INVOICE_NUMBER");

            builder.Property(im => im.Date)
                .IsRequired()
                .HasColumnName("DATE");

            builder.Property(im => im.Place)
                .IsRequired()
                .HasMaxLength(75)
                .HasColumnName("PLACE");

            builder.Property(im => im.TransactionDate)
                .IsRequired()
                .HasColumnName("TRANSACTION_DATE");

            builder.Property(im => im.State)
                .HasColumnName("STATE");

            builder.Property(im => im.Kind)
                .HasColumnName("KIND");

            builder.Property(im => im.CurrencyCode)
                .IsRequired()
                .HasMaxLength(35)
                .HasColumnName("CURRENCY_CODE");

            builder.Property(im => im.PaymentMethod)
                .IsRequired()
                .HasMaxLength(35)
                .HasColumnName("PAYMENT_METHOD");

            builder.Property(im => im.PaymentDeadline)
                .HasMaxLength(35)
                .HasColumnName("PAYMENT_DEADLINE");

            builder.Property(im => im.AmountPaid)
                .HasColumnType("decimal(10,2)")
                .HasColumnName("AMOUNT_PAID");
        }
    }
}
