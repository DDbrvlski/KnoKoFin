using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.DeleteServiceType
{
    public class DeleteServiceTypeCommand : IRequest
    {
        public long Id { get; set; }
    }
}
