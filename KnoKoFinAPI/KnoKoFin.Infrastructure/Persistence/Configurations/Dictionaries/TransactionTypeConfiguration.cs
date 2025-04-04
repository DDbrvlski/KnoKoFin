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
    public class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.ToTable("transaction_type", "dictionaries");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("NAME");

            builder.Property(x => x.Type)
                .HasColumnName("TYPE");
        }
    }
}
