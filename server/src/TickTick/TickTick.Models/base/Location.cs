using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTick.Models
{
    public enum LocationType
    {
        PRIMARY=0,
        WORK=1,
        HOME=2,
        OTHER=3
    }
    public sealed class Location: BaseEntity
    {
        public string Street { get; set; }
        public string Nr { get; set; }
        public string City { get; set; }
        public string? State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public LocationType Type { get; set; } = LocationType.PRIMARY;

        public Location(string street, string nr, string city, string zipcode, string country) 
        {
            this.Street = street;
            this.Nr = nr;
            this.City = city;
            this.ZipCode = zipcode;
            this.Country = country;

        }

        public Location(string street, string nr, string city, string zipcode, string country,string state):this(street, nr, city, zipcode, country)
        {
            this.State = state;

        }

        public override string ToString()
        {
            return $"{this.Street} {this.Nr}, {this.City}";
        }
    }
}
