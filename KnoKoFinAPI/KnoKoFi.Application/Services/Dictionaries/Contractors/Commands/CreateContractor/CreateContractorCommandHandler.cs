using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Interfaces;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Interfaces;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.CreateContractor
{
    public class CreateContractorCommandHandler : IRequestHandler<CreateContractorCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContractorAppService _contractorAppService;
        private readonly ILogger<CreateContractorCommandHandler> _logger;
        public CreateContractorCommandHandler
            (IUnitOfWork unitOfWork,
            IContractorAppService contractorAppService,
            ILogger<CreateContractorCommandHandler> logger,r)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _contractorAppService = contractorAppService;
        }

        public async Task<long> Handle(CreateContractorCommand request, CancellationToken cancellationToken)
        {

            var contractor = CreateContractorCommandMapper.CommandToContractor(request);

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var addedContractor = await _contractorAppService.CreateContractorAsync(request, cancellationToken);

                await _unitOfWork.CommitTransactionAsync();

                return addedContractor.Id;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new CreateFailureException(nameof(DictionaryContractor), contractor, $"Wystąpił błąd podczas tworzenia: {ex.Message}");
            }
        }
    }
}
