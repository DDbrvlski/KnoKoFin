using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Dto;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.UpdateContractor;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Dto;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Interfaces;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Interfaces;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors
{
    public class ContractorAppService : IContractorAppService
    {
        private readonly IDictionaryContractorRepository _contractorRepository;
        private readonly IGetContractorDetailsRepository _contractorDetailsRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger<ContractorAppService> _logger;

        public ContractorAppService
            (ILogger<ContractorAppService> logger,
            IDictionaryContractorRepository contractorRepository,
            IGetContractorDetailsRepository contractorDetailsRepository,
            IAddressRepository addressRepository,
            IUnitOfWork unitOfWork)
        {
            _contractorRepository = contractorRepository;
            _addressRepository = addressRepository;
            _logger = logger;
            _contractorDetailsRepository = contractorDetailsRepository;
        }

        public async Task<UpdateContractorResultDto> UpdateContractorAsync(UpdateContractorCommand command, CancellationToken cancellationToken)
        {
            var contractor = await _contractorRepository.GetByIdAsync(command.Id, cancellationToken)
                ?? throw new NotFoundException($"Contractor with ID {command.Id} not found.");

            Address? address = null;

            if (contractor.AddressId.HasValue)
            {
                var addressToUpdate = await _addressRepository.GetByIdAsync(contractor.AddressId.Value, cancellationToken)
                    ?? throw new NotFoundException($"Address with ID {contractor.AddressId.Value} not found.");

                addressToUpdate.Update(command.Address.City, command.Address.Country, command.Address.PostCode, command.Address.Street);
                address = await _addressRepository.UpdateAsync(addressToUpdate, cancellationToken);
            }
            else if (command.Address != null)
            {
                address = Address.Create(command.Address.City, command.Address.Country, command.Address.PostCode, command.Address.Street);
                address = await _addressRepository.CreateAsync(address, cancellationToken);
            }

            contractor = UpdateContractorCommandMapper.ApplyUpdate(contractor, command);

            if (address != null)
                contractor.SetAddress(address.Id);

            await _contractorRepository.UpdateAsync(contractor, cancellationToken);

            var updated = await _contractorDetailsRepository.GetContractorDetails(contractor.Id, cancellationToken);

            return UpdateContractorCommandMapper.GetContractorDetailsToUpdateContractorResult(updated);
        }

    }

}
