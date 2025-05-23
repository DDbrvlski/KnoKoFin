using KnoKoFin.Application.DTOs;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Dto
{
    public class AddressDetailsDto : BaseDto
    {
        public long Id { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
    }
}
