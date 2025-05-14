using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Enums;
using KnoKoFin.Infrastructure.Persistence.Configurations.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries
{
    public class TransactionTypeConfiguration : BaseModelConfiguration<TransactionType>, IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.ToTable("transaction_type", "dictionaries");

            builder.Property(tt => tt.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("NAME");

            builder.Property(tt => tt.Type)
                .HasColumnName("TYPE");

            builder.Property(t => t.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (TransactionTypeEnum)Enum.Parse(typeof(TransactionTypeEnum), v)
                );
        }
    }
}
