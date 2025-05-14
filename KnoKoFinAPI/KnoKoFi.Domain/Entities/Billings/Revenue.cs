using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Entities.Invoices;
using KnoKoFin.Domain.Enums;
using KnoKoFin.Domain.Helpers;

namespace KnoKoFin.Domain.Entities.Billings
{
    public class Revenue : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalNetPrice { get; set; }
        public decimal TotalGrossPrice { get; set; }
        public long CategoryId { get; set; }
        public long? InvoiceId { get; set; }
        public long? ContractorId { get; set; }

        public virtual TransactionTypeEnum TransactionType { get; set; }
        public virtual Invoice? Invoice { get; set; }
        public virtual Dictionaries.DictionaryContractor? Contractor { get; set; }
        public virtual ICollection<RevenuePosition> Positions { get; set; }
    }
}
