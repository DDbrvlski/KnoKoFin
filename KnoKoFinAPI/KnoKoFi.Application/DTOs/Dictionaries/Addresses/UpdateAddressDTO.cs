using System.ComponentModel.DataAnnotations;

namespace KnoKoFin.Application.DTOs.Dictionaries.Addresses
{
    public class UpdateAddressDTO : IAddressCommon
    {
        [Required]
        public int Id { get; set; }



        [Required]
        public byte[] RowVersion { get; set; }
    }
}
