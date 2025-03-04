using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries;

namespace KnoKoFin.DTOs.Dictionaries.Addresses
{
    [AutoMap(typeof(Address))]
    public class CreateAddressDTO
    {
        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [Required]
        [MaxLength(10)]
        public string PostCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
    }
}
