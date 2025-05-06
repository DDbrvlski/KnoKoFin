using KnoKoFin.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Helpers
{
    public class BaseModelConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseModel
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName($"PK_{typeof(TEntity).Name}_ID");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasColumnName("CREATED_AT")
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.UpdatedAt)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasColumnName("UPDATED_AT")
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.DeletedAt)
                .HasColumnType("datetime2")
                .HasColumnName("DELETED_AT");

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName("IS_ACTIVE");

            builder.Property(x => x.CreatedBy)
                .HasMaxLength(36)
                .HasColumnType("varchar(36)")
                .HasColumnName("CREATED_BY");

            builder.Property(x => x.UpdatedBy)
                .HasMaxLength(36)
                .HasColumnType("varchar(36)")
                .HasColumnName("UPDATED_BY");

            builder.Property(x => x.RowVersion)
                .IsRowVersion()
                .HasColumnName("ROW_VERSION");
        }
    }
}
