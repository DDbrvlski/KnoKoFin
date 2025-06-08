using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServiceTypes.Commands.DeleteTransactionServiceType
{
    public class DeleteTransactionServiceTypeCommand : IRequest
    {
        public long Id { get; set; }
    }
}
