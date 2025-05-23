﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator.Models
{
    public class SellerInvoiceDto
    {
        public string Name { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string? HouseNumber { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
