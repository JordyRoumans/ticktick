using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using TickTick.Api.Persons;
using TickTick.Api.ResponseWrappers;
using TickTick.Api.Services;
using TickTick.Models;
using TickTick.Models.Dtos;

namespace TickTick.Api.Controllers
{
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsService svc;
        public PersonsController(IPersonsService service) 
        {
            this.svc = service;
        }

        [HttpGet]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>),200)]
        public IActionResult Get()
        {
            try
            {
                List<Person> people = new List<Person>();
                people.Add(new Person("Kevin", "DeRudder", "kevin.derudder@elmos.be"));
                people.Add(new Person("Jordy", "Schuermans", "jordy.schuermans@assign.be"));

                Response<IEnumerable<Person>> resp = new Response<IEnumerable<Person>>();
                resp.Data = people;
                return Ok(resp);
            }
            catch (Exception ex) 
            {
                Response<IEnumerable<Person>> resp = new Response<IEnumerable<Person>>();
                resp.Data = null;
                resp.Message = ex.Message;
                resp.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return (StatusCode(500, resp));

            }

        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        public IActionResult Get(Guid id) 
        {
            //TODO: haal persoon op
            Person person = new Person("Jordy", "Schuermans", "jordy.schuermans@assign.be");
            return Ok(person.ConvertToDto());
        }


        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        public IActionResult Delete(Guid id) 
        {
            svc.DeletePerson(id);
            return NoContent();
        }


        public IActionResult Post([FromBody] AddPersonDto person)
        {
           PersonDto newP = svc.AddPerson(person);
           return CreatedAtAction(nameof(Get), new { id = newP.PublicId }, person);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        public IActionResult Put(Guid id, [FromBody] PersonDto person)
        {
            PersonDto newP = svc.UpdatePerson(id, person);
            return Ok(newP);
        }
    }
}
 