using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Dto;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Interfaces;
using KnoKoFin.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.UpdateContractor
{
    public class UpdateContractorCommandHandler : IRequestHandler<UpdateContractorCommand, UpdateContractorResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateContractorCommandHandler> _logger;
        private readonly IContractorAppService _contractorService;
        public UpdateContractorCommandHandler
            (IUnitOfWork unitOfWork,
            IContractorAppService contractorService,
            ILogger<UpdateContractorCommandHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _contractorService = contractorService;
        }

        public async Task<UpdateContractorResultDto> Handle(UpdateContractorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Rozpoczęcie aktualizacji kontrahenta o ID {request.Id}.");
            try
            {

                await _unitOfWork.BeginTransactionAsync();

                var result = await _contractorService.UpdateContractorAsync(request, cancellationToken);

                await _unitOfWork.CommitTransactionAsync();
                _logger.LogInformation("Sukces aktualizacji kontrahenta: {Id}", request.Id);

                return result;
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
