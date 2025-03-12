using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries
{
    public class ContractorConfiguration : IEntityTypeConfiguration<Contractor>
    {
        public void Configure(EntityTypeBuilder<Contractor> builder)
        {
            // Tabela i schemat
            builder.ToTable("contractors", schema: "dictionaries");

            // Kolumny
            builder.Property(c => c.ContractorType)
                .IsRequired()
                .HasColumnName("CONTRACTOR_TYPE")
                .HasColumnType("varchar(30)")
                .HasMaxLength(30);

            builder.Property(c => c.Name)
                .HasColumnName("NAME")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(c => c.FirstName)
                .HasColumnName("FIRST_NAME")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45);

            builder.Property(c => c.LastName)
                .HasColumnName("LAST_NAME")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45);

            builder.Property(c => c.Description)
                .HasColumnName("DESCRIPTION")
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);

            builder.Property(c => c.Archival)
                .IsRequired()
                .HasColumnName("ARCHIVAL");

            builder.Property(c => c.Nip)
                .HasColumnName("NIP")
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            builder.Property(c => c.Email)
                .HasColumnName("EMAIL")
                .HasColumnType("varchar(75)")
                .HasMaxLength(75);

            builder.Property(c => c.PhoneNumber)
                .HasColumnName("PHONE_NUMBER")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder.Property(c => c.BankAccountNumber)
                .IsRequired()
                .HasColumnName("BANK_ACCOUNT_NUMBER")
                .HasColumnType("varchar(26)")
                .HasMaxLength(26);

            builder.Property(c => c.BankName)
                .IsRequired()
                .HasColumnName("BANK_NAME")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45);

            builder.Property(c => c.Fax)
                .HasColumnName("FAX")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45);

            builder.Property(c => c.Swift)
                .HasColumnName("SWIFT")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45);

            builder.Property(c => c.AddressId)
                .HasColumnName("ADDRESS_ID");

            // Relacje
            builder.HasOne(c => c.Address)
                   .WithMany()
                   .HasForeignKey(c => c.AddressId);
        }
    }
}
