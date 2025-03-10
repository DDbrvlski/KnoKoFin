﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.DTOs.Dictionaries.Addresses
{
    public class UpdateAddressDTO : IAddressCommon
    {
        [Required]
        public int Id { get; set; }



        [Required]
        public byte[] RowVersion { get; set; }
    }
}
