using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.DTOs.Dictionaries.Addresses
{
    public class GetAddressDetailsDTO
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
