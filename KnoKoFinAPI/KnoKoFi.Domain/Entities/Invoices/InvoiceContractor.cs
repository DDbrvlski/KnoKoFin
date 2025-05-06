using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Helpers;

namespace KnoKoFin.Domain.Entities.Invoices
{
    public class InvoiceContractor : BaseModel
    {
        public string ContractorType { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Nip { get; set; }
        public string? PhoneNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public long? AddressId { get; set; }
        public virtual Address? Address { get; set; }
    }

}
