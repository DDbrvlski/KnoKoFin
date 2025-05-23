using KnoKoFin.Application.DTOs;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommand : IRequest<UpdateAddressCommand>
    {
        public long Id { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
