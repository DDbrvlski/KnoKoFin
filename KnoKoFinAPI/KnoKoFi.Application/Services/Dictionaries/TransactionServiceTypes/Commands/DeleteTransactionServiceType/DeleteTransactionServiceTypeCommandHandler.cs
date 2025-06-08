using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServiceTypes.Commands.DeleteTransactionServiceType
{
    public class DeleteTransactionServiceTypeCommandHandler : IRequestHandler<DeleteTransactionServiceTypeCommand>
    {
        private readonly ILogger<DeleteTransactionServiceTypeCommandHandler> _logger;
        private readonly ITransactionServiceTypeRepository _serviceTypeRepository;

        public DeleteTransactionServiceTypeCommandHandler
            (ILogger<DeleteTransactionServiceTypeCommandHandler> logger,
            ITransactionServiceTypeRepository serviceTypeRepository)
        {
            _logger = logger;
            _serviceTypeRepository = serviceTypeRepository;
        }

        public async Task Handle(DeleteTransactionServiceTypeCommand request, CancellationToken cancellationToken)
        {
            await _serviceTypeRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
