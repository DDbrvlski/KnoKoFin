﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.DeleteContractor
{
    public class DeleteContractorCommand : IRequest
    {
        public long Id { get; set; }
    }
}
