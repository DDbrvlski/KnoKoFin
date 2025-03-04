using KnoKoFin.Infrastructure.Persistence.Configurations.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries
{
    [Table("services", Schema = "dictionaries")]
    public class Service : BaseModel
    {
        [MaxLength(255)]
        [Column("NAME")]
        public string? Name { get; set; }

        [MaxLength(255)]
        [Column("DESCRIPTION")]
        public string? Description { get; set; }

        [Required]
        [Column("ARCHIVAL")]
        public bool Archival { get; set; } = false;

        [Column("DISCOUNT", TypeName = "decimal(10,2)")]
        public decimal? Discount { get; set; }

        [Column("NET_PRICE", TypeName = "decimal(10,2)")]
        public decimal? NetPrice { get; set; }

        [Column("GROSS_PRICE", TypeName = "decimal(10,2)")]
        public decimal? GrossPrice { get; set; }

        [Column("VAT", TypeName = "decimal(10,2)")]
        public decimal? Vat { get; set; }

        [MaxLength(10)]
        [Column("UNIT")]
        public string? Unit { get; set; }

        [Column("QUANTITY")]
        public int? Quantity { get; set; }
    }
}
