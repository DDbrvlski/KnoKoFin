using KnoKoFin.Domain.Entities.Billings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Domain.Entities.Invoices
{
    [Table("invoices", Schema = "invoices")]
    public class Invoice
    {
        [ForeignKey("Metadata")]
        [Column("INVOICE_METADATA_ID")]
        public long InvoiceMetadataId { get; set; }

        [ForeignKey("InternalContractor")]
        [Column("INTERNAL_INVOICE_CONTRACTOR_ID")]
        public long InternalInvoiceContractorId { get; set; }

        [ForeignKey("ExternalContractor")]
        [Column("EXTERNAL_INVOICE_CONTRACTOR_ID")]
        public long ExternalInvoiceContractorId { get; set; }

        [ForeignKey("Revenue")]
        [Column("REVENUE")]
        public long? RevenueId { get; set; }

        public virtual InvoiceMetadata Metadata { get; set; }
        public virtual Contractor InternalContractor { get; set; }
        public virtual Contractor ExternalContractor { get; set; }
        public virtual Revenue? Revenue { get; set; }
    }
}
