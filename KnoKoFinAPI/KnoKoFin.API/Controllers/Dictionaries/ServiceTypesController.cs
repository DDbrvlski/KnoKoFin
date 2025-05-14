using KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.CreateContractor;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.DeleteContractor;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.UpdateContractor;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Queries.GetContractorDetails;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Queries.GetContractorList;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.CreateServiceType;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.DeleteServiceType;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.UpdateServiceType;
using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Queries.GetServiceTypeList;
using KnoKoFin.Domain.Entities.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace KnoKoFin.API.Controllers.Dictionaries
{
    public class ServiceTypesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var contractors = await Mediator.Send(new GetServiceTypeListQuery { });

            return Ok(contractors);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateServiceTypeCommand command)
        {
            var entityId = await Mediator.Send(command);

            return CreatedAtAction(nameof(ServiceType), new { id = entityId }, null);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateServiceTypeCommand command)
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
            await Mediator.Send(new DeleteServiceTypeCommand { Id = id });

            return NoContent();
        }
    }
}
