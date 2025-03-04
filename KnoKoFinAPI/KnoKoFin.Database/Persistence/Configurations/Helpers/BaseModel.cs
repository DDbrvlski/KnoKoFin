using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Helpers
{
    public class BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID", TypeName = "bigint")]
        public long Id { get; set; }

        [Required]
        [Column("CREATED_AT", TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("UPDATED_AT", TypeName = "datetime2")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("DELETED_AT", TypeName = "datetime2")]
        public DateTime? DeletedAt { get; set; }

        [Required]
        [Column("IS_ACTIVE", TypeName = "boolean")]
        public bool IsActive { get; set; } = false;

        [Column("CREATED_BY", TypeName = "varchar(36)")]
        public string? CreatedBy { get; set; }

        [Column("UPDATED_BY", TypeName = "varchar(36)")]
        public string? UpdatedBy { get; set; }


        [Timestamp]
        [Column("ROW_VERSION", TypeName = "rowversion")]
        public byte[] RowVersion { get; set; } = new byte[8];
    }
}
