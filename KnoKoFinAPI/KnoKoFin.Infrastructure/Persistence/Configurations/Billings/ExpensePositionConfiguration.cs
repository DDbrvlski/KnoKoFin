using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Infrastructure.Persistence.Configurations.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Billings
{
    public class ExpensePositionConfiguration : BaseModelConfiguration<ExpensePosition>, IEntityTypeConfiguration<ExpensePosition>
    {
        public void Configure(EntityTypeBuilder<ExpensePosition> builder)
        {
            builder.ToTable("expenses_positions", "billing");

            //builder.Property(ep => ep.Name)
            //    .IsRequired()
            //    .HasMaxLength(255)
            //    .HasColumnName("NAME");

            builder.Property(ep => ep.ExpenseId)
                .HasColumnName("EXPENSE_ID")
                .IsRequired();

            builder.Property(ep => ep.ServiceId)
                .HasColumnName("SERVICE_ID")
                .IsRequired();

            builder.HasOne(ep => ep.Expense)
                .WithMany(e => e.Positions)
                .HasForeignKey(ep => ep.ExpenseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ep => ep.Service)
                .WithMany()
                .HasForeignKey(ep => ep.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
