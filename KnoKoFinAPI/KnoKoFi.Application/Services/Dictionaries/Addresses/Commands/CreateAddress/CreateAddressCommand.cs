using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<CreateAddressCommand>
    {
        public long? Id {  get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
