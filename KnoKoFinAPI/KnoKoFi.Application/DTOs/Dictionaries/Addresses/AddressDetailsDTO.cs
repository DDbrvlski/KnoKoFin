namespace KnoKoFin.Application.DTOs.Dictionaries.Addresses
{
    public class AddressDetailsDTO : IAddressCommon
    {
        public long Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
