using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.DeleteServiceType
{
    public class DeleteTransactionServiceTypeCommand : IRequest
    {
        public long Id { get; set; }
    }
}
