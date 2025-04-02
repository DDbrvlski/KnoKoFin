using Azure.Core;
using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Infrastructure.Common.Interfaces;
using KnoKoFin.Infrastructure.Repositories.Dictionaries.Addresses;
using KnoKoFin.Infrastructure.Repositories.Dictionaries.Contractors;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.UpdateContractor
{
    public class UpdateContractorService : IUpdateContractorService
    {
        private readonly IContractorRepository _contractorRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger<UpdateContractorService> _logger;

        public UpdateContractorService
            (ILogger<UpdateContractorService> logger,
            IContractorRepository contractorRepository,
            IAddressRepository addressRepository,
            IUnitOfWork unitOfWork)
        {
            _contractorRepository = contractorRepository;
            _addressRepository = addressRepository;
            _logger = logger;
        }

        public async Task<Contractor> UpdateContractorAsync(Contractor contractorToUpdate, UpdateContractorCommand updateContractorCommand, Address address, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Aktualizacja kontrahenta o ID {contractorToUpdate.Id}.");

            contractorToUpdate.Update(
                    updateContractorCommand.ContractorType,
                    updateContractorCommand.Name,
                    updateContractorCommand.FirstName,
                    updateContractorCommand.LastName,
                    updateContractorCommand.Description,
                    updateContractorCommand.Nip,
                    updateContractorCommand.Email,
                    updateContractorCommand.PhoneNumber,
                    updateContractorCommand.BankAccountNumber,
                    updateContractorCommand.BankName,
                    updateContractorCommand.Fax,
                    updateContractorCommand.Swift
                );

            if (address != null)
            {
                contractorToUpdate.SetAddress(address.Id);
            }
            return await _contractorRepository.UpdateAsync(contractorToUpdate, cancellationToken);
        }

        public async Task<Address?> UpdateOrCreateAddressAsync(Contractor contractorToUpdate, UpdateAddressCommand? addressCommand, CancellationToken cancellationToken)
        {
            if (contractorToUpdate.AddressId.HasValue)
            {
                return await UpdateAddressAsync(contractorToUpdate.AddressId.Value, addressCommand, cancellationToken);
            }
            else
            {
                return addressCommand != null ? await CreateAddressAsync(addressCommand, cancellationToken) : null;
            }

        }

        public async Task<Contractor> GetContractorById(long id)
        {
            var contractor = await _contractorRepository.GetByIdAsync(id);
            if (contractor == null)
            {
                _logger.LogError($"Nie znaleziono kontrahenta o ID {id}.");
                throw new NotFoundException($"Contractor with ID {id} not found.");
            }
            return contractor;
        }

        private async Task<Address> UpdateAddressAsync(long addressId, UpdateAddressCommand addressCommand, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Aktualizacja adresu o ID {addressId}.");
            var addressToUpdate = await _addressRepository.GetByIdAsync(addressId);
            if (addressToUpdate == null)
            {
                throw new UpdateFailureException(nameof(Address), addressId, "Adres nie został znaleziony.");
            }
            addressToUpdate.Update(addressCommand.City, addressCommand.Country, addressCommand.PostCode, addressCommand.Street);
            return await _addressRepository.UpdateAsync(addressToUpdate, cancellationToken);
        }

        private async Task<Address> CreateAddressAsync(UpdateAddressCommand addressCommand, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Tworzenie nowego adresu.");
            var newAddress = Address.Create(addressCommand.City, addressCommand.Country, addressCommand.PostCode, addressCommand.Street);
            return await _addressRepository.CreateAsync(newAddress, cancellationToken);
        }

    }

}
