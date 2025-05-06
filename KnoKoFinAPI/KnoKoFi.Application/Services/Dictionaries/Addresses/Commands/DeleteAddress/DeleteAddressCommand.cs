using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.DeleteAddress
{
    public class DeleteAddressCommand : IRequest
    {
        public long Id { get; set; }
    }
}
