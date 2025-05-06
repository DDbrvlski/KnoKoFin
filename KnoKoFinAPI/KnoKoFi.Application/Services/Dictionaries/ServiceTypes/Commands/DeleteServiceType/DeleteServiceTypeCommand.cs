using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.DeleteServiceType
{
    public class DeleteServiceTypeCommand : IRequest
    {
        public long Id { get; set; }
    }
}
