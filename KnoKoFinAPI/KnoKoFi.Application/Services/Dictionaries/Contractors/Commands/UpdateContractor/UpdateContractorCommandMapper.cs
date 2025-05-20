using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress;
using KnoKoFin.Domain.Entities.Dictionaries;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.UpdateContractor
{
    public static class UpdateContractorCommandMapper
    {
        public static DictionaryContractor ToEntity(UpdateContractorCommand updateContractor)
        {

            var contractor = DictionaryContractor.Create(
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

            if (updateContractor.Address.Id != null)
            {
                contractor.AddressId = updateContractor.Address.Id;
            }

            return contractor;
        }

        public static UpdateContractorCommand ToCommand(DictionaryContractor contractor)
        {
            return new UpdateContractorCommand()
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
                Fax = contractor.Fax,
                Swift = contractor.Swift,
                Address = new UpdateAddressCommand()
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
