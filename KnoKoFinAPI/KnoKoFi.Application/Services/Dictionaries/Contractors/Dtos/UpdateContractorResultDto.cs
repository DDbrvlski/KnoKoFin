using KnoKoFin.Application.DTOs;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Dtos
{
    public class UpdateContractorResultDto : BaseDto
    {
        public long Id { get; set; }
        public string ContractorType { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Description { get; set; }
        public string? Nip { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string? Fax { get; set; }
        public string? Swift { get; set; }
        public UpdateAddressResultDto? Address { get; set; }
    }
}
