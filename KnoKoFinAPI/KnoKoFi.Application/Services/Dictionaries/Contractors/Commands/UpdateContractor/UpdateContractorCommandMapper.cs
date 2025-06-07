using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Dto;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.CreateContractor;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Dtos;
using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.UpdateContractor
{
    public static class UpdateContractorCommandMapper
    {
        public static DictionaryContractor ApplyUpdate(DictionaryContractor contractor, UpdateContractorCommand updateContractor)
        {
            contractor.Update(
                updateContractor.ContractorType,
                updateContractor.Name,
                updateContractor.FirstName,
                updateContractor.LastName,
                updateContractor.Description,
                updateContractor.Nip,
                updateContractor.Email,
                updateContractor.PhoneNumber,
                updateContractor.BankAccountNumber,
                updateContractor.BankName,
                updateContractor.Fax,
                updateContractor.Swift
            );

            return contractor;
        }

        public static UpdateContractorResultDto GetContractorDetailsToUpdateContractorResult(ContractorDetailsDto contractor)
        {
            return new UpdateContractorResultDto()
            {
                Id = contractor.Id,
                FirstName = contractor.FirstName,
                LastName = contractor.LastName,
                Description = contractor.Description,
                Nip = contractor.Nip,
                Email = contractor.Email,
                PhoneNumber = contractor.PhoneNumber,
                BankAccountNumber = contractor.BankAccountNumber,
                BankName = contractor.BankName,
                ContractorType = contractor.ContractorType,
                Name = contractor.Name,
                Fax = contractor.Fax,
                CreatedAt = contractor.CreatedAt,
                LastModifiedAt = contractor.LastModifiedAt,
                RowVersion = contractor.RowVersion,
                Swift = contractor.Swift,
                Address = new UpdateAddressResultDto()
                {
                    Id = contractor.Address.Id,
                    City = contractor.Address.City,
                    Country = contractor.Address.Country,
                    Street = contractor.Address.Street,
                    PostCode = contractor.Address.PostCode
                }
            };
        }
    }
}
