using KnoKoFin.Application.DTOs;
using KnoKoFin.Application.Services.Dictionaries.TransactionServices.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServices.Commands.UpdateTransactionService
{
    public class UpdateTransactionServiceCommand : BaseCommand, IRequest<UpdateServiceResultDto>
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Discount { get; set; }
        public decimal? NetPrice { get; set; }
        public decimal? GrossPrice { get; set; }
        public decimal? Vat { get; set; }
        public string? Unit { get; set; }
        public int? Quantity { get; set; }
    }
}
