using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Infrastructure.Common.Interfaces;
using KnoKoFin.Infrastructure.Repositories.Dictionaries.Contractors;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.UpdateContractor
{
    public class UpdateContractorCommandHandler : IRequestHandler<UpdateContractorCommand, UpdateContractorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateContractorCommandHandler> _logger;
        private readonly UpdateContractorCommandMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUpdateContractorService _service;
        public UpdateContractorCommandHandler
            (IUnitOfWork unitOfWork,
            IUpdateContractorService service,
            ILogger<UpdateContractorCommandHandler> logger,
            UpdateContractorCommandMapper mapper,
            IMediator mediator)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _service = service;
            _mapper = mapper;
        }

        public async Task<UpdateContractorCommand> Handle(UpdateContractorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Rozpoczęcie aktualizacji kontrahenta o ID {request.ContractorId}.");
            try
            {

                await _unitOfWork.BeginTransactionAsync();

                var contractorToUpdate = await _service.GetContractorById(request.ContractorId);

                var updatedAddress = await _service.UpdateOrCreateAddressAsync(contractorToUpdate, request.Address, cancellationToken);
                _logger.LogInformation($"Zaktualizowano lub utworzono adres o ID {updatedAddress.Id}.");

                var updatedContractor = await _service.UpdateContractorAsync(contractorToUpdate, request, updatedAddress, cancellationToken);
                _logger.LogInformation($"Zaktualizowano kontrahenta o ID {updatedContractor.Id}.");

                await _unitOfWork.CommitTransactionAsync();

                _logger.LogInformation($"Pomyślnie zmodyfikowano kontrahenta o ID {updatedContractor.Id}.");
                return _mapper.Map(updatedContractor);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                _logger.LogError($"Wystąpił błąd podczas modyfikowania kontrahenta o ID {request.ContractorId}", ex.Message);
                throw new UpdateFailureException(nameof(request), request.ContractorId, "Wystąpił błąd podczas aktualizacji kontrahenta.");
            }
        }
    }
}
