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
        public long? TransactionTypeId { get; set; }

        public virtual TransactionType TransactionType { get; set; }
        public virtual Invoice? Invoice { get; set; }
        public virtual Dictionaries.DictionaryContractor? Contractor { get; set; }
        public virtual List<BillingTransactionService>? BillingTransactionService { get; private set; }

        private Revenue() { }

        public static Revenue Create(
            string name,
            string? description,
            DateTime saleDate,
            decimal totalNetPrice,
            decimal totalGrossPrice,
            long? contractorId,
            long? transactionTypeId)
        {
            return new Revenue
            {
                Name = name,
                Description = description,
                SaleDate = saleDate,
                TotalNetPrice = totalNetPrice,
                TotalGrossPrice = totalGrossPrice,
                ContractorId = contractorId,
                TransactionTypeId = transactionTypeId
            };
        }

        public void Update(
            string name,
            string? description,
            DateTime saleDate,
            decimal totalNetPrice,
            decimal totalGrossPrice,
            long? contractorId,
            long? transactionTypeId)
        {
            Name = name;
            Description = description;
            SaleDate = saleDate;
            TotalNetPrice = totalNetPrice;
            TotalGrossPrice = totalGrossPrice;
            ContractorId = contractorId;
            TransactionTypeId = transactionTypeId;
        }
    }
}
