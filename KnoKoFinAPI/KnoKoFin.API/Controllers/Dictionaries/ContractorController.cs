using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.CreateAddress;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.DeleteAddress;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Queries.GetAddressDetails;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.CreateContractor;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.DeleteContractor;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.UpdateContractor;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Queries.GetContractorDetails;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Queries.GetContractorList;
using Microsoft.AspNetCore.Mvc;

namespace KnoKoFin.API.Controllers.Dictionaries
{
    public class ContractorController : BaseController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(long id)
        {
            var contractor = await Mediator.Send(new GetContractorDetailsQuery { Id = id });

            if (contractor == null)
            {
                return NotFound();
            }

            return Ok(contractor);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var contractors = await Mediator.Send(new GetContractorListQuery { });

            return Ok(contractors);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateContractorCommand command)
        {
            var entityId = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = entityId }, null);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateContractorCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Przesłane id się nie zgadzają.");
            }

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(long id)
        {
            await Mediator.Send(new DeleteContractorCommand { Id = id });

            return NoContent();
        }
    }
}
