using TickTick.Api.Persons;
using TickTick.Models;
using TickTick.Models.Dtos;

namespace TickTick.Api.Services
{
    public class PersonsService : IPersonsService
    {
        public PersonDto AddPerson(AddPersonDto dto)
        {
            Person person = new Person(

                dto.FirstName,
                dto.LastName,
                dto.Email);

            person.CreatePublicId();
            return person.ConvertToDto();
            
        }

        public void DeletePerson(Guid id)
        {
            //Todo: Persoon ophalen
            //als persoon null is geef 404 terug
            //p.Delete()
            //save
            //indien persoon niet null is delete en return 204
        }

        public PersonDto UpdatePerson(Guid personId, PersonDto dto)
        {
            //TODO: use person from db
            Person person = new Person(
                dto.FirstName,
                dto.Lastname,
                dto.Email
                );
            person.Update(dto);
            return person.ConvertToDto();
        }
    }
}
