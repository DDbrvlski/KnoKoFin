using KnoKoFin.Domain.Helpers;
using KnoKoFin.Infrastructure.Common.Exceptions;

namespace KnoKoFin.Domain.Entities.Dictionaries
{
    public class Contractor : BaseModel
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
        public long? AddressId { get; set; }


        public virtual Address? Address { get; set; }

        private Contractor() { }

        public void SetAddress(long addressId)
        {
            if (addressId <= 0)
            {
                throw new InvalidIndexValueException(nameof(Address), addressId, "id <= 0");
            }
            AddressId = addressId;
        }
        public static Contractor Create
            (string contractorType, string name, string firstName,
            string lastName, string description, string nip,
            string email, string phoneNumber, string bankAccountNumber,
            string bankName, string fax, string swift)
        {
            return new Contractor
            {
                ContractorType = contractorType,
                Name = name,
                FirstName = firstName,
                LastName = lastName,
                Description = description,
                Nip = nip,
                Email = email,
                PhoneNumber = phoneNumber,
                BankAccountNumber = bankAccountNumber,
                BankName = bankName,
                Fax = fax,
                Swift = swift
            };
        }

        public void Update
            (string contractorType, string name, string firstName,
            string lastName, string description, string nip,
            string email, string phoneNumber, string bankAccountNumber,
            string bankName, string fax, string swift)
        {
            ContractorType = contractorType;
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            Nip = nip;
            Email = email;
            PhoneNumber = phoneNumber;
            BankAccountNumber = bankAccountNumber;
            BankName = bankName;
            Fax = fax;
            Swift = swift;
        }
    }
}
