using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Enums;
using KnoKoFin.Domain.Helpers;

namespace KnoKoFin.Domain.Entities.Billings
{
    public class BillingService : BaseModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Archival { get; set; } = false;
        public decimal? Discount { get; set; }
        public decimal? NetPrice { get; set; }
        public decimal? GrossPrice { get; set; }
        public decimal? Vat { get; set; }
        public UnityTypeEnum? Unit { get; set; }
        public int? Quantity { get; set; }
        public long? ServiceTypeId { get; set; }
        public virtual TransactionServiceType? ServiceType { get; set; }

        private BillingService() { }

        public static BillingService Create
            (string? name, string? description, decimal? discount,
             decimal? netPrice, decimal? grossPrice, decimal? vat,
             UnityTypeEnum? unit, int? quantity, long? serviceTypeId)
        {
            return new BillingService
            {
                Name = name,
                Description = description,
                Discount = discount,
                NetPrice = netPrice,
                GrossPrice = grossPrice,
                Vat = vat,
                Unit = unit,
                Quantity = quantity,
                ServiceTypeId = serviceTypeId
            };
        }

        public void Update
            (string? name, string? description, decimal? discount,
             decimal? netPrice, decimal? grossPrice, decimal? vat,
             UnityTypeEnum? unit, int? quantity, long? serviceTypeId)
        {
            Name = name;
            Description = description;
            Discount = discount;
            NetPrice = netPrice;
            GrossPrice = grossPrice;
            Vat = vat;
            Unit = unit;
            Quantity = quantity;
            ServiceTypeId = serviceTypeId;
        }
    }

}
