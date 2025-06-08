using KnoKoFin.Domain.Helpers;

namespace KnoKoFin.Domain.Entities.Dictionaries
{
    public class DictionaryTransactionService : BaseModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Archival { get; set; } = false;
        public decimal? Discount { get; set; }
        public decimal? NetPrice { get; set; }
        public decimal? GrossPrice { get; set; }
        public decimal? Vat { get; set; }
        public string? Unit { get; set; }
        public int? Quantity { get; set; }
        public int? ServiceTypeId { get; set; }

        public TransactionServiceType? ServiceType { get; set; }

        public void Update(string? name, string? description, decimal? discount, decimal? netPrice, decimal? grossPrice, decimal? vat, string? unit, int? quantity)
        {
            Name = name;
            Description = description;
            Discount = discount;
            NetPrice = netPrice;
            GrossPrice = grossPrice;
            Vat = vat;
            Unit = unit;
            Quantity = quantity;
        }
        public static DictionaryTransactionService Create(string? name, string? description, decimal? discount, decimal? netPrice, decimal? grossPrice, decimal? vat, string? unit, int? quantity)
        {
            return new DictionaryTransactionService
            {
                Name = name,
                Description = description,
                Discount = discount,
                NetPrice = netPrice,
                GrossPrice = grossPrice,
                Vat = vat,
                Unit = unit,
                Quantity = quantity,
            };
        }
    }
}
