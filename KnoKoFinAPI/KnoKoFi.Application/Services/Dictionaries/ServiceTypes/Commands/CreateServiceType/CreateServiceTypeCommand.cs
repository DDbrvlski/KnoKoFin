using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.CreateServiceType
{
    public class CreateServiceTypeCommand : IRequest<CreateServiceTypeDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
