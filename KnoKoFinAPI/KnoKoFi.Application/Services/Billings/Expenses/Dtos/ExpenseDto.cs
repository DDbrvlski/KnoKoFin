using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Expenses.Dtos
{
    public class ExpenseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalGrossPrice { get; set; }
        public string ContractorName { get; set; }
        public string TransactionTypeName { get; set; }
    }
}
