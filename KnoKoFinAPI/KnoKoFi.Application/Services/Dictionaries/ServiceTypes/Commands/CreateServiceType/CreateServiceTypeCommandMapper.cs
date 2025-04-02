using KnoKoFin.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.CreateServiceType
{
    public class CreateServiceTypeCommandMapper
    {
        public ServiceType Map(CreateServiceTypeCommand command)
        {
            return ServiceType.Create(command.Name, command.Description);
        }
        public CreateServiceTypeDto Map(ServiceType serviceType)
        {
            return new CreateServiceTypeDto()
            {
                Id= serviceType.Id,
                Name= serviceType.Name,
                Description= serviceType.Description
            };
        }
    }
}
