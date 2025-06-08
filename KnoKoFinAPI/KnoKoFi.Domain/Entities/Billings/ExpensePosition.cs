using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Enums;
using KnoKoFin.Domain.Helpers;
using System.Xml.Linq;

namespace KnoKoFin.Domain.Entities.Billings
{
    public class ExpensePosition : BaseModel
    {
        //public string Name { get; set; }
        public long ExpenseId { get; private set; }
        public long ServiceId { get; private set; }

        public virtual Expense Expense { get; set; }
        public virtual BillingTransactionService Service { get; set; }

        private ExpensePosition()
        {
            
        }

        public static ExpensePosition Create
            (long expenseId, long serviceId)
        {
            return new ExpensePosition
            {
                ExpenseId = expenseId,
                ServiceId = serviceId
            };
        }

        public void Update
            (long expenseId, long serviceId)
        {
            ExpenseId = expenseId;
            ServiceId = serviceId;
        }
    }
}
