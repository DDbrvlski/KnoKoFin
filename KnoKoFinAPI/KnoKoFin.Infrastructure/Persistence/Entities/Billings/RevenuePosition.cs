using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Billings
{
    [Table("revenues_positions", Schema = "billing")]
    public class RevenuePosition
    {
        [Required]
        [MaxLength(255)]
        [Column("NAME")]
        public string Name { get; set; }

        [ForeignKey("Revenue")]
        [Column("REVENUE_ID")]
        public long RevenueId { get; set; }

        [ForeignKey("Service")]
        [Column("SERVICE_ID")]
        public long ServiceId { get; set; }

        public virtual Revenue Revenue { get; set; }
        public virtual Service Service { get; set; }
    }
}
