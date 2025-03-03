using KnoKoFin.Database.Models.Dictionaries;
using KnoKoFin.Database.Models.Invoices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Database.Models.Billings
{
    [Table("revenues", Schema = "billing")]
    public class Revenue
    {
        [Required]
        [MaxLength(255)]
        [Column("NAME")]
        public string Name { get; set; }

        [MaxLength(500)]
        [Column("DESCRIPTION")]
        public string? Description { get; set; }

        [Required]
        [Column("SALE_DATE")]
        public DateTime SaleDate { get; set; }

        [Column("TOTAL_NET_PRICE", TypeName = "decimal(10,2)")]
        public decimal TotalNetPrice { get; set; }

        [Column("TOTAL_GROSS_PRICE", TypeName = "decimal(10,2)")]
        public decimal TotalGrossPrice { get; set; }

        [ForeignKey("Category")]
        [Column("CATEGORY_ID")]
        public long CategoryId { get; set; }

        [ForeignKey("Invoice")]
        [Column("INVOICE_ID")]
        public long? InvoiceId { get; set; }

        [ForeignKey("Contractor")]
        [Column("CONTRACTOR_ID")]
        public long? ContractorId { get; set; }

        public virtual TransactionType Category { get; set; }
        public virtual Invoice? Invoice { get; set; }
        public virtual Dictionaries.Contractor? Contractor { get; set; }
        public virtual ICollection<RevenuePosition> Positions { get; set; }
    }
}
