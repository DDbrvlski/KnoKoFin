using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Services.Commands.CreateService
{
    public class CreateServiceCommand : IRequest<long>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Discount { get; set; }
        public decimal? NetPrice { get; set; }
        public decimal? GrossPrice { get; set; }
        public decimal? Vat { get; set; }
        public string? Unit { get; set; }
        public int? Quantity { get; set; }
        public int? ServiceTypeId { get; set; }
    }
}
