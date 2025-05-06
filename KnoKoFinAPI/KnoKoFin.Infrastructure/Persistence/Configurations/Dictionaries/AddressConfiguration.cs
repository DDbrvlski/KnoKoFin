using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Infrastructure.Persistence.Configurations.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries
{
    public class AddressConfiguration : BaseModelConfiguration<Address>, IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("addresses", schema: "dictionaries");

            builder.Property(a => a.Street)
                .IsRequired()
                .HasColumnName("STREET")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(a => a.PostCode)
                .IsRequired()
                .HasColumnName("POSTCODE")
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            builder.Property(a => a.City)
                .IsRequired()
                .HasColumnName("CITY")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(a => a.Country)
                .IsRequired()
                .HasColumnName("COUNTRY")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);
        }
    }
}
