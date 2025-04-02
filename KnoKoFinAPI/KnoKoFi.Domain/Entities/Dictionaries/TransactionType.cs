using KnoKoFin.Domain.Enums;
using KnoKoFin.Domain.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnoKoFin.Domain.Entities.Dictionaries
{
    [Table("transaction_type", Schema = "dictionaries")]
    public class TransactionType : BaseModel
    {
        [Required]
        [MaxLength(100)]
        [Column("NAME")]
        public string Name { get; set; }

        [Column("TYPE")]
        public TransactionTypeEnum Type { get; set; }
    }
}
