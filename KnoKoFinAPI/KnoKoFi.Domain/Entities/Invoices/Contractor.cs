using KnoKoFin.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Domain.Entities.Invoices
{
    [Table("contractors", Schema = "invoices")]
    public class Contractor
    {
        [Column("CONTRACTOR_TYPE")]
        public string ContractorType { get; set; }

        [MaxLength(100)]
        [Column("NAME")]
        public string? Name { get; set; }

        [MaxLength(45)]
        [Column("FIRST_NAME")]
        public string? FirstName { get; set; }

        [MaxLength(45)]
        [Column("LAST_NAME")]
        public string? LastName { get; set; }

        [MaxLength(10)]
        [Column("NIP")]
        public string? Nip { get; set; }

        [MaxLength(20)]
        [Column("PHONE_NUMBER")]
        public string? PhoneNumber { get; set; }

        [Required]
        [MaxLength(26)]
        [Column("BANK_ACCOUNT_NUMBER")]
        public string BankAccountNumber { get; set; }

        [Required]
        [MaxLength(45)]
        [Column("BANK_NAME")]
        public string BankName { get; set; }

        [ForeignKey("Address")]
        [Column("ADDRESS_ID")]
        public long? AddressId { get; set; }

        public virtual Address? Address { get; set; }
    }
}
