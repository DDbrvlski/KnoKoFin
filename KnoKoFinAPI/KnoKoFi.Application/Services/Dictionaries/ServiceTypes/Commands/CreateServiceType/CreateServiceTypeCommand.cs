using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.CreateServiceType
{
    public class CreateServiceTypeCommand : IRequest<CreateServiceTypeDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
