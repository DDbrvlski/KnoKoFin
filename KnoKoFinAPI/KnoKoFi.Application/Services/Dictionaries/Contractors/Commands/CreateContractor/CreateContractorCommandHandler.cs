using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Infrastructure.Common.Interfaces;
using KnoKoFin.Infrastructure.Repositories.Dictionaries.Addresses;
using KnoKoFin.Infrastructure.Repositories.Dictionaries.Contractors;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.CreateContractor
{
    public class CreateContractorCommandHandler : IRequestHandler<CreateContractorCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreateContractorCommandMapper _mapper;
        private readonly ILogger<CreateContractorCommandHandler> _logger;
        private readonly IAddressRepository _addressRepository;
        private readonly IContractorRepository _contractorRepository;
        private readonly IMediator _mediator;
        public CreateContractorCommandHandler
            (CreateContractorCommandMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger<CreateContractorCommandHandler> logger,
            IAddressRepository addressRepository,
            IContractorRepository contractorRepository,
            IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mediator = mediator;
            _addressRepository = addressRepository;
            _contractorRepository = contractorRepository;
        }

        public async Task<long> Handle(CreateContractorCommand request, CancellationToken cancellationToken)
        {

            var contractor = _mapper.MapContractor(request);

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
                throw new CreateFailureException(nameof(Contractor), contractor, $"Wystąpił błąd podczas tworzenia: {ex.Message}");
            }
        }
    }
}
