using KnoKoFin.Application.DTOs;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Expenses.Dtos
{
    public class ExpenseDetailsDto : BaseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalNetPrice { get; set; }
        public decimal TotalGrossPrice { get; set; }
        public ContractorDetailsDto ContractorDetails { get; set; }

        public string TransactionType { get; set; }
    }
}
