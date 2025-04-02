using KnoKoFin.Domain.Interfaces;
using KnoKoFin.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.DeleteContractor
{
    public class DeleteContractorCommandHandler : IRequestHandler<DeleteContractorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteContractorCommandHandler> _logger;
        private readonly IAddressRepository _addressRepository;
        private readonly IContractorRepository _contractorRepository;

        public DeleteContractorCommandHandler
            (IUnitOfWork unitOfWork,
            ILogger<DeleteContractorCommandHandler> logger,
            IAddressRepository addressRepository,
            IContractorRepository contractorRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _addressRepository = addressRepository;
            _contractorRepository = contractorRepository;
        }

        public async Task Handle(DeleteContractorCommand request, CancellationToken cancellationToken)
        {

            var addressIdToDelete = await _contractorRepository.GetContractorAddressId(request.Id);
            if (addressIdToDelete != null && request.Id == addressIdToDelete.ContractorId && addressIdToDelete.AddressId != null)
            {
                await _contractorRepository.DeleteAsync(request.Id, cancellationToken);
                await _addressRepository.DeleteAsync((long)addressIdToDelete.AddressId, cancellationToken);
            }
        }
    } 
}
