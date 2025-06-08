using KnoKoFin.Application.Services.Dictionaries.TransactionServiceTypes.Dtos;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServiceTypes.Commands.UpdateTransactionServiceType
{
    public class UpdateTransactionServiceTypeCommand : IRequest<UpdateTransactionServiceTypeResultDto>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
