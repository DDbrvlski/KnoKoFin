using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.CreateAddress;
using KnoKoFin.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.CreateContractor
{
    public class CreateContractorCommandMapper
    {
        public Contractor MapContractor(CreateContractorCommand command)
        {
            return Contractor.Create
                (
                    command.ContractorType, 
                    command.Name, 
                    command.FirstName, 
                    command.LastName,
                    command.Description, 
                    command.Nip, 
                    command.Email, 
                    command.PhoneNumber, 
                    command.BankAccountNumber,
                    command.BankName, 
                    command.Fax, 
                    command.Swift
                );
        }
        public Address MapAddress(CreateAddressCommand command)
        {
            return Address.Create
                (
                    command.City,
                    command.Country,
                    command.PostCode,
                    command.Street
                );
        }
    }
}
