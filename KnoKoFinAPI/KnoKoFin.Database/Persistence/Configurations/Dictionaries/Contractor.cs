using KnoKoFin.Infrastructure.Persistence.Configurations.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries
{
    [Table("contractors", Schema = "dictionaries")]
    public class Contractor : BaseModel
    {
        [Required]
        [Column("CONTRACTOR_TYPE", TypeName = "varchar(30)")]
        [MaxLength(30)]
        public string ContractorType { get; set; }

        [MaxLength(100)]
        [Column("NAME", TypeName = "varchar(100)")]
        public string? Name { get; set; }

        [MaxLength(45)]
        [Column("FIRST_NAME", TypeName = "varchar(45)")]
        public string? FirstName { get; set; }

        [MaxLength(45)]
        [Column("LAST_NAME", TypeName = "varchar(45)")]
        public string? LastName { get; set; }

        [MaxLength(255)]
        [Column("DESCRIPTION", TypeName = "varchar(255)")]
        public string? Description { get; set; }

        [Required]
        [Column("ARCHIVAL")]
        public bool Archival { get; set; } = false;

        [MaxLength(10)]
        [Column("NIP", TypeName = "varchar(10)")]
        public string? Nip { get; set; }

        [MaxLength(75)]
        [EmailAddress]
        [Column("EMAIL", TypeName = "varchar(75)")]
        public string? Email { get; set; }

        [MaxLength(20)]
        [Phone]
        [Column("PHONE_NUMBER", TypeName = "varchar(20)")]
        public string? PhoneNumber { get; set; }

        [Required]
        [MaxLength(26)]
        [Column("BANK_ACCOUNT_NUMBER", TypeName = "varchar(26)")]
        public string BankAccountNumber { get; set; }

        [Required]
        [MaxLength(45)]
        [Column("BANK_NAME", TypeName = "varchar(45)")]
        public string BankName { get; set; }

        [MaxLength(45)]
        [Column("FAX", TypeName = "varchar(45)")]
        public string? Fax { get; set; }

        [MaxLength(45)]
        [Column("SWIFT", TypeName = "varchar(45)")]
        public string? Swift { get; set; }

        [ForeignKey("Address")]
        [Column("ADDRESS_ID")]
        public long? AddressId { get; set; }


        public virtual Address? Address { get; set; }
    }
}
