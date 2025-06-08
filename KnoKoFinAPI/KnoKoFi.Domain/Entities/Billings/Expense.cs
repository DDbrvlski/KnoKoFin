using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Enums;
using KnoKoFin.Domain.Helpers;

namespace KnoKoFin.Domain.Entities.Billings
{
    public class Expense : BaseModel
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public decimal TotalNetPrice { get; private set; }
        public decimal TotalGrossPrice { get; private set; }
        public long? ContractorId { get; private set; }
        public long? TransactionTypeId { get; private set; }

        public virtual TransactionType TransactionType { get; private set; }
        public virtual DictionaryContractor? Contractor { get; private set; }
        public virtual List<BillingTransactionService>? BillingTransactionService { get; private set; }

        private Expense() { }

        public static Expense Create(
            string name,
            string? description,
            DateTime purchaseDate,
            decimal totalNetPrice,
            decimal totalGrossPrice,
            long? contractorId,
            long? transactionTypeId)
        {
            return new Expense
            {
                Name = name,
                Description = description,
                PurchaseDate = purchaseDate,
                TotalNetPrice = totalNetPrice,
                TotalGrossPrice = totalGrossPrice,
                ContractorId = contractorId,
                TransactionTypeId = transactionTypeId
            };
        }

        public void Update(
            string name,
            string? description,
            DateTime purchaseDate,
            decimal totalNetPrice,
            decimal totalGrossPrice,
            long? contractorId,
            long? transactionTypeId)
        {
            Name = name;
            Description = description;
            PurchaseDate = purchaseDate;
            TotalNetPrice = totalNetPrice;
            TotalGrossPrice = totalGrossPrice;
            ContractorId = contractorId;
            TransactionTypeId = transactionTypeId;
        }
    }
}
