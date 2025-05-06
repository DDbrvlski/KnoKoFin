using KnoKoFin.Domain.Helpers;

namespace KnoKoFin.Domain.Entities.Dictionaries
{
    public class Address : BaseModel
    {
        public string Street { get; private set; }
        public string PostCode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        private Address() { }

        public static Address Create(string city, string country, string postCode, string street)
        {
            return new Address
            {
                City = city,
                Country = country,
                PostCode = postCode,
                Street = street
            };
        }
        public void Update(string city, string country, string postCode, string street)
        {
            Street = street;
            City = city;
            Country = country;
            PostCode = postCode;

        }
    }
}
