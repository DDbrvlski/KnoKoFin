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
    [Table("addresses", Schema = "dictionaries")]
    public class Address : BaseModel
    {
        [Required]
        [Column("STREET", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Street { get; set; }

        [Required]
        [Column("POSTCODE", TypeName = "varchar(10)")]
        [MaxLength(10)]
        public string PostCode { get; set; }

        [Required]
        [Column("CITY", TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [Column("COUNTRY", TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string Country { get; set; }
    }
}
