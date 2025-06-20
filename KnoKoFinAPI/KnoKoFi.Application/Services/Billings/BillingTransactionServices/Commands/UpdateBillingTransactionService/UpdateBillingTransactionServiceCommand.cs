﻿using KnoKoFin.Application.DTOs;
using KnoKoFin.Application.Services.Billings.BillingTransactionServices.Dtos;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingTransactionServices.Commands.UpdateBillingTransactionService
{
    public class UpdateBillingTransactionServiceCommand : BaseCommand, IRequest<UpdateBillingTransactionServiceResultDto>
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Archival { get; set; } = false;
        public decimal? Discount { get; set; }
        public decimal? NetPrice { get; set; }
        public decimal? GrossPrice { get; set; }
        public decimal? Vat { get; set; }
        public string? Unit { get; set; }
        public int? Quantity { get; set; }
        public long? ServiceTypeId { get; set; }
    }
}
