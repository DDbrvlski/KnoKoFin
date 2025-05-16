using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator.Models
{
    public class AdditionalInfoInvoiceDto
    {
        public string PaymentMethodName { get; set; }
        public string CurrencyName { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string DeliveryName { get; set; }
        public decimal DeliveryPrice { get; set; }
    }
}
