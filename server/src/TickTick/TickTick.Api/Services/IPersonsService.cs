using TickTick.Api.Persons;
using TickTick.Models;
using TickTick.Models.Dtos;

namespace TickTick.Api.Services
{
    public interface IPersonsService
    {
        void DeletePerson(Guid id);
        public PersonDto AddPerson(AddPersonDto dto);
        public PersonDto UpdatePerson(Guid personId, PersonDto dto);
    }
}