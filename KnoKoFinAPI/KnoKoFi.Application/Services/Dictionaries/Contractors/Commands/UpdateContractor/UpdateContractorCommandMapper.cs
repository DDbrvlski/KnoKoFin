using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress;
using KnoKoFin.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.UpdateContractor
{
    public class UpdateContractorCommandMapper
    {
        public Contractor Map(UpdateContractorCommand updateContractor)
        {

            var contractor = Contractor.Create(
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

        public UpdateContractorCommand Map(Contractor contractor)
        {
            return new UpdateContractorCommand()
            {
                ContractorId = contractor.Id,
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
