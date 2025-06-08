using KnoKoFin.Application.Services.Dictionaries.TransactionServiceTypes.Dtos;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServiceTypes.Commands.CreateTransactionServiceType
{
    public class CreateTransactionServiceTypeCommand : IRequest<CreateTransactionServiceTypeResultDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
