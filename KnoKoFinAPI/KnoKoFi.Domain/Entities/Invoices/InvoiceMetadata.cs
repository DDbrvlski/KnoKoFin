using KnoKoFin.Domain.Enums;
using KnoKoFin.Domain.Helpers;

namespace KnoKoFin.Domain.Entities.Invoices
{
    public class InvoiceMetadata : BaseModel
    {
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public DateTime TransactionDate { get; set; }
        public InvoiceStateTypeEnum State { get; set; }
        public InvoiceKindTypeEnum Kind { get; set; }
        public string CurrencyCode { get; set; }
        public string PaymentMethod { get; set; }
        public string? PaymentDeadline { get; set; }
        public decimal AmountPaid { get; set; }
    }

}
