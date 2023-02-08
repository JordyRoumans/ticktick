using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TickTick.Models;

namespace TickTick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person("Kevin", "DeRudder", "kevin.derudder@elmos.be"));
            people.Add(new Person("Jordy", "Schuermans", "jordy.schuermans@assign.be"));
            return Ok(people);

        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id) 
        {
            //TODO: haal persoon op
            Person person = new Person("Jordy", "Schuermans", "jordy.schuermans@assign.be");
            return Ok(person);
        }
    }
}
 