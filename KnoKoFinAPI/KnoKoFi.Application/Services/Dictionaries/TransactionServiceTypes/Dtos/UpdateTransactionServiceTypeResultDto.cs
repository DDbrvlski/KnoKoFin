﻿using KnoKoFin.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServiceTypes.Dtos
{
    public class UpdateTransactionServiceTypeResultDto : BaseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
