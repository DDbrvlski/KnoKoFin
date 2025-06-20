﻿using KnoKoFin.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Dtos
{
    public class UpdateAddressResultDto : BaseDto
    {
        public long Id { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
