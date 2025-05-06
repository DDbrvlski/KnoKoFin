using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Infrastructure.Persistence.Configurations.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries
{
    public class ServiceTypeConfiguration : BaseModelConfiguration<ServiceType>, IEntityTypeConfiguration<ServiceType>
    {
        public void Configure(EntityTypeBuilder<ServiceType> builder)
        {
            builder.ToTable("service_type", "dictionaries");

            builder.Property(st => st.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)")
                .HasColumnName("NAME");

            builder.Property(st => st.Description)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("varchar(500)")
                .HasColumnName("DESCRIPTION");
        }
    }
}
