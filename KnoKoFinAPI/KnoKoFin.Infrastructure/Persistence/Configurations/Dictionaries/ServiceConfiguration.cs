using KnoKoFin.Domain.Entities.Dictionaries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("services", "dictionaries");

            builder.Property(x => x.Name)
                .HasMaxLength(255)
                .HasColumnName("NAME");

            builder.Property(x => x.Description)
                .HasMaxLength(255)
                .HasColumnName("DESCRIPTION");

            builder.Property(x => x.Archival)
                .IsRequired()
                .HasColumnName("ARCHIVAL");

            builder.Property(x => x.Discount)
                .HasColumnType("decimal(10,2)")
                .HasColumnName("DISCOUNT");

            builder.Property(x => x.NetPrice)
                .HasColumnType("decimal(10,2)")
                .HasColumnName("NET_PRICE");

            builder.Property(x => x.GrossPrice)
                .HasColumnType("decimal(10,2)")
                .HasColumnName("GROSS_PRICE");

            builder.Property(x => x.Vat)
                .HasColumnType("decimal(10,2)")
                .HasColumnName("VAT");

            builder.Property(x => x.Unit)
                .HasMaxLength(10)
                .HasColumnName("UNIT");

            builder.Property(x => x.Quantity)
                .HasColumnName("QUANTITY");
        }
    }
}
