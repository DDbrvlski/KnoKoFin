using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.CreateAddress;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.DeleteAddress;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Queries.GetAddressDetails;
using Microsoft.AspNetCore.Mvc;

namespace KnoKoFin.API.Controllers.Dictionaries
{
    public class AddressController : BaseController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(long id)
        {
            var address = await Mediator.Send(new GetAddressDetailsQuery { Id = id });

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateAddressCommand command)
        {
            var entityId = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = entityId }, null);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateAddressCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Id in the route does not match id in the body.");
            }

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete([FromBody] DeleteAddressCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
