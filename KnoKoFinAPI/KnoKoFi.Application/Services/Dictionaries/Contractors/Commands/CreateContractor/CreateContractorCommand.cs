using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.CreateAddress;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.CreateContractor
{
    public class CreateContractorCommand : IRequest<long>
    {
        public string ContractorType { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Description { get; set; }
        public bool Archival { get; set; } = false;
        public string? Nip { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string? Fax { get; set; }
        public string? Swift { get; set; }
        public CreateAddressCommand Address { get; set; }
    }
}
