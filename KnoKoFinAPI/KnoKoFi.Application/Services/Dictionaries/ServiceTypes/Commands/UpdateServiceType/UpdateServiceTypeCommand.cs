using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.UpdateServiceType
{
    public class UpdateServiceTypeCommand : IRequest<UpdateServiceTypeCommand>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
