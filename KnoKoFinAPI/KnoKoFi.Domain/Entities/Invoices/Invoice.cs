using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Helpers;

namespace KnoKoFin.Domain.Entities.Invoices
{
    public class Invoice : BaseModel
    {
        public long InvoiceMetadataId { get; set; }
        public long InternalInvoiceContractorId { get; set; }
        public long ExternalInvoiceContractorId { get; set; }
        public long? RevenueId { get; set; }

        public virtual InvoiceMetadata Metadata { get; set; }
        public virtual InvoiceContractor InternalContractor { get; set; }
        public virtual InvoiceContractor ExternalContractor { get; set; }
        public virtual Revenue? Revenue { get; set; }
    }

}
