using KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.CreateContractor;
using Microsoft.AspNetCore.Mvc;

namespace KnoKoFin.API.Controllers.Dictionaries
{
    public class ContractorController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateContractorCommand command)
        {
            var entityId = await Mediator.Send(command);

            //return CreatedAtAction(nameof(GetById), new { id = entityId }, null);
            return Created();
        }
    }
}
