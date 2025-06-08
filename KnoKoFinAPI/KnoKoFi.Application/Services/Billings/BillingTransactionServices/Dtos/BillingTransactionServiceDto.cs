using KnoKoFin.Application.DTOs;
using KnoKoFin.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingTransactionServices.Dtos
{
    public class BillingTransactionServiceDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ServiceTypeName { get; set; }

    }
}
