using KnoKoFin.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Domain.Entities.Billings
{
    [Table("expenses", Schema = "billing")]
    public class Expense
    {
        [Required]
        [MaxLength(255)]
        [Column("NAME")]
        public string Name { get; set; }

        [MaxLength(500)]
        [Column("DESCRIPTION")]
        public string? Description { get; set; }

        [Required]
        [Column("PURCHASE_DATE")]
        public DateTime PurchaseDate { get; set; }

        [Column("TOTAL_NET_PRICE", TypeName = "decimal(10,2)")]
        public decimal TotalNetPrice { get; set; }

        [Column("TOTAL_GROSS_PRICE", TypeName = "decimal(10,2)")]
        public decimal TotalGrossPrice { get; set; }

        [ForeignKey("Category")]
        [Column("CATEGORY_ID")]
        public long CategoryId { get; set; }

        [ForeignKey("Contractor")]
        [Column("CONTRACTOR_ID")]
        public long? ContractorId { get; set; }

        public virtual TransactionType Category { get; set; }
        public virtual Contractor? Contractor { get; set; }
        public virtual ICollection<ExpensePosition> Positions { get; set; }
    }
}
