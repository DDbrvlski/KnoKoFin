using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Infrastructure.Persistence.Configurations.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Billings
{
    public class RevenuePositionConfiguration : BaseModelConfiguration<RevenuePosition>, IEntityTypeConfiguration<RevenuePosition>
    {
        public void Configure(EntityTypeBuilder<RevenuePosition> builder)
        {
            builder.ToTable("revenues_positions", "billing");

            builder.Property(rp => rp.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("NAME");

            builder.Property(rp => rp.RevenueId)
                .HasColumnName("REVENUE_ID")
                .IsRequired();

            builder.Property(rp => rp.ServiceId)
                .HasColumnName("SERVICE_ID")
                .IsRequired();

            builder.HasOne(rp => rp.Revenue)
                .WithMany(r => r.Positions)
                .HasForeignKey(rp => rp.RevenueId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rp => rp.Service)
                .WithMany()
                .HasForeignKey(rp => rp.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
