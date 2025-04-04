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
    public class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceType>
    {
        public void Configure(EntityTypeBuilder<ServiceType> builder)
        {
            builder.ToTable("service_type", "dictionaries");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)")
                .HasColumnName("NAME");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("varchar(500)")
                .HasColumnName("DESCRIPTION");
        }
    }
}
