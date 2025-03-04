using KnoKoFin.Infrastructure.Persistence.Configurations.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Invoices
{
    [Table("invoice_metadata", Schema = "invoices")]
    public class InvoiceMetadata
    {
        [Required]
        [MaxLength(15)]
        [Column("INVOICE_NUMBER")]
        public string InvoiceNumber { get; set; }

        [Required]
        [Column("DATE")]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(75)]
        [Column("PLACE")]
        public string Place { get; set; }

        [Required]
        [Column("TRANSACTION_DATE")]
        public DateTime TransactionDate { get; set; }

        [Column("STATE")]
        public InvoiceStateTypeEnum State { get; set; }

        [Column("KIND")]
        public InvoiceKindTypeEnum Kind { get; set; }

        [Required]
        [MaxLength(35)]
        [Column("CURRENCY_CODE")]
        public string CurrencyCode { get; set; }

        [Required]
        [MaxLength(35)]
        [Column("PAYMENT_METHOD")]
        public string PaymentMethod { get; set; }

        [MaxLength(35)]
        [Column("PAYMENT_DEADLINE")]
        public string? PaymentDeadline { get; set; }

        [Column("AMOUNT_PAID", TypeName = "decimal(10,2)")]
        public decimal AmountPaid { get; set; }
    }
}
