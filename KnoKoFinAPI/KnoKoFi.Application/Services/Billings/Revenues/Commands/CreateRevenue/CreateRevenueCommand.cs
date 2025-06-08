using KnoKoFin.Application.Services.Billings.Expenses.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Revenues.Commands.CreateRevenue
{
    public class CreateRevenueCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalNetPrice { get; set; }
        public decimal TotalGrossPrice { get; set; }
        public long? ContractorId { get; set; }
        public long? TransactionTypeId { get; set; }
        public List<CreateBillingServiceDto> BillingServices { get; set; }
    }
}
