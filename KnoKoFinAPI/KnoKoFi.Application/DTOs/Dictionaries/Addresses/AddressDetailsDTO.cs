using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.DTOs.Dictionaries.Addresses
{
    public class AddressDetailsDTO : IAddressCommon
    {
        public long Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
