using KnoKoFin.Domain.Entities.Invoices;
using KnoKoFin.Infrastructure.Persistence.Configurations.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Invoices
{
    public class ContractorConfiguration : BaseModelConfiguration<InvoiceContractor>, IEntityTypeConfiguration<InvoiceContractor>
    {
        public void Configure(EntityTypeBuilder<InvoiceContractor> builder)
        {
            builder.ToTable("contractors", "invoices");

            builder.Property(c => c.ContractorType)
                .HasColumnName("CONTRACTOR_TYPE")
                .HasMaxLength(30);

            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .HasColumnName("NAME");

            builder.Property(c => c.FirstName)
                .HasMaxLength(45)
                .HasColumnName("FIRST_NAME");

            builder.Property(c => c.LastName)
                .HasMaxLength(45)
                .HasColumnName("LAST_NAME");

            builder.Property(c => c.Nip)
                .HasMaxLength(10)
                .HasColumnName("NIP");

            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("PHONE_NUMBER");

            builder.Property(c => c.BankAccountNumber)
                .IsRequired()
                .HasMaxLength(26)
                .HasColumnName("BANK_ACCOUNT_NUMBER");

            builder.Property(c => c.BankName)
                .IsRequired()
                .HasMaxLength(45)
                .HasColumnName("BANK_NAME");

            builder.Property(c => c.AddressId)
                .HasColumnName("ADDRESS_ID");

            builder.HasOne(c => c.Address)
                .WithMany()
                .HasForeignKey(c => c.AddressId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
