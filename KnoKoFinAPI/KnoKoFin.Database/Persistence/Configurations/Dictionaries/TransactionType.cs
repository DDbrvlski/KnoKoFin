using KnoKoFin.Infrastructure.Persistence.Configurations.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries
{
    [Table("transaction_type", Schema = "dictionaries")]
    public class TransactionType
    {
        [Required]
        [MaxLength(100)]
        [Column("NAME")]
        public string Name { get; set; }

        [Column("TYPE")]
        public TransactionTypeEnum Type { get; set; }
    }
}
