using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Enums;
using KnoKoFin.Domain.Helpers;

namespace KnoKoFin.Domain.Entities.Billings
{
    public class Expense : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalNetPrice { get; set; }
        public decimal TotalGrossPrice { get; set; }
        public long CategoryId { get; set; }
        public long? ContractorId { get; set; }

        public virtual TransactionTypeEnum TransactionType { get; set; }
        public virtual DictionaryContractor? Contractor { get; set; }
        public virtual ICollection<ExpensePosition> Positions { get; set; }
    }
}
