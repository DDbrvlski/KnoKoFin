using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.UpdateContractor
{
    public class UpdateContractorCommandHandler : IRequestHandler<UpdateContractorCommand, UpdateContractorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateContractorCommandHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IUpdateContractorService _service;
        public UpdateContractorCommandHandler
            (IUnitOfWork unitOfWork,
            IUpdateContractorService service,
            ILogger<UpdateContractorCommandHandler> logger,
            IMediator mediator)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _service = service;
        }

        public async Task<UpdateContractorCommand> Handle(UpdateContractorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Rozpoczęcie aktualizacji kontrahenta o ID {request.Id}.");
            try
            {

                await _unitOfWork.BeginTransactionAsync();

                var contractorToUpdate = await _service.GetContractorById(request.Id, cancellationToken);

                var updatedAddress = await _service.UpdateOrCreateAddressAsync(contractorToUpdate, request.Address, cancellationToken);
                _logger.LogInformation($"Zaktualizowano lub utworzono adres o ID {updatedAddress.Id}.");

                var updatedContractor = await _service.UpdateContractorAsync(contractorToUpdate, request, updatedAddress, cancellationToken);
                _logger.LogInformation($"Zaktualizowano kontrahenta o ID {updatedContractor.Id}.");

                await _unitOfWork.CommitTransactionAsync();

                _logger.LogInformation($"Pomyślnie zmodyfikowano kontrahenta o ID {updatedContractor.Id}.");
                return UpdateContractorCommandMapper.Map(updatedContractor);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                _logger.LogError($"Wystąpił błąd podczas modyfikowania kontrahenta o ID {request.Id}", ex.Message);
                throw new UpdateFailureException(nameof(request), request.Id, "Wystąpił błąd podczas aktualizacji kontrahenta.");
            }
        }
    }
}
