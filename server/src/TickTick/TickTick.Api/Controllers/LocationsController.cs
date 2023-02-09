using Microsoft.AspNetCore.Mvc;
using TickTick.Api.ResponseWrappers;
using TickTick.Models.Dtos;

namespace TickTick.Api.Controllers
{
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class LocationsController : Controller
    {
        [HttpGet("v{v:apiVersion}/person/{personId:guid}/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<LocationDto>), 200)]
        public IActionResult GetLocations()
        {
            List<LocationDto> locations = new List<LocationDto>()
            {
            };
            return Ok(new Response<IEnumerable<LocationDto>>(locations));
        }
    }
}
