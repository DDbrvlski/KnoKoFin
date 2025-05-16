using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator.Models
{
    public class InvoiceDto
    {
        public string InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public CustomerInvoiceDto CustomerData { get; set; }
        public SellerInvoiceDto SellerData { get; set; }
        public AdditionalInfoInvoiceDto AdditionalInfoData { get; set; }
        public List<ProductInvoiceDto> InvoiceProductsData { get; set; }
    }
}
