using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dtos;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.UpdateServiceType
{
    public class UpdateTransactionServiceTypeCommand : IRequest<UpdateTransactionServiceTypeResultDto>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
