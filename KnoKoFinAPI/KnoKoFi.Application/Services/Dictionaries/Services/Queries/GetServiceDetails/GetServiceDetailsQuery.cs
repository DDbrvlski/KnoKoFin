using KnoKoFin.Application.Services.Dictionaries.Services.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Services.Queries.GetServiceDetails
{
    public class GetServiceDetailsQuery : IRequest<ServiceDetailsDto>
    {
        public long Id { get; set; }
    }
}
