using KnoKoFin.Application.Common.Exceptions;
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
        private readonly ILogger<CreateContractorCommandHandler> _logger;
        private readonly IAddressRepository _addressRepository;
        private readonly IDictionaryContractorRepository _contractorRepository;
        private readonly IMediator _mediator;
        public CreateContractorCommandHandler
            (IUnitOfWork unitOfWork,
            ILogger<CreateContractorCommandHandler> logger,
            IAddressRepository addressRepository,
            IDictionaryContractorRepository contractorRepository,
            IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mediator = mediator;
            _addressRepository = addressRepository;
            _contractorRepository = contractorRepository;
        }

        public async Task<long> Handle(CreateContractorCommand request, CancellationToken cancellationToken)
        {

            var contractor = CreateContractorCommandMapper.CommandToContractor(request);

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var addedAddress = await _mediator.Send(request.Address, cancellationToken);
                // Przypisanie ID utworzonego adresu do contractora
                contractor.SetAddress((long)addedAddress.Id);

                var addedContractor = await _contractorRepository.CreateAsync(contractor, cancellationToken);

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
