using KnoKoFin.Domain.Helpers;

namespace KnoKoFin.Domain.Entities.Billings
{
    public class ExpensePosition : BaseModel
    {
        public string Name { get; set; }
        public long ExpenseId { get; set; }
        public long ServiceId { get; set; }

        public virtual Expense Expense { get; set; }
        public virtual BillingService Service { get; set; }
    }
}
