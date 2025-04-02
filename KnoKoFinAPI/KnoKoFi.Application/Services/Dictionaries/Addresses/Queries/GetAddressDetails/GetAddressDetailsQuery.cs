using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Queries.GetAddressDetails
{
    public class GetAddressDetailsQuery : IRequest<AddressDetailsDto>
    {
        public long Id { get; set; }
    }
}
