using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTick.Models.Dtos
{
    public class PersonDto
    {
        public Guid PublicId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}
