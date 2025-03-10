using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.CreateAddress;
using Microsoft.AspNetCore.Mvc;

namespace KnoKoFin.API.Controllers.Dictionaries
{
    public class AddressController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateAddressCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
