using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Infrastructure.Persistence.Configurations.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries
{
    public class TransactionServiceTypeConfiguration : BaseModelConfiguration<TransactionServiceType>, IEntityTypeConfiguration<TransactionServiceType>
    {
        public void Configure(EntityTypeBuilder<TransactionServiceType> builder)
        {
            builder.ToTable("transaction_service_type", "dictionaries");

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
