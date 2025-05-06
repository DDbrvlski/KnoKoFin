using KnoKoFin.Domain.Helpers;

namespace KnoKoFin.Domain.Entities.Billings
{
    public class RevenuePosition : BaseModel
    {
        public string Name { get; set; }
        public long RevenueId { get; set; }
        public long ServiceId { get; set; }

        public virtual Revenue Revenue { get; set; }
        public virtual BillingService Service { get; set; }
    }

}
