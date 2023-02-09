﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickTick.Models.Dtos;

namespace TickTick.Models
{
    public class Person :BaseAuditableEntity, IEquatable<Person>
    {
        public  Guid PublicId { get; private set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? SocialSecurityNumber { get; set; }
        public DateTime? DateOfBirth  { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public IList<Location>? Address { get; set; }
        public bool IsDeleted { get; private set; }


        public Person(string firstname, string lastname, string email)
        {
            this.FirstName= firstname;
            this.LastName= lastname;
            this.Email= email;
        }
        

        public PersonDto ConvertToDto()
        {
            return new PersonDto()
            {
                PublicId = this.PublicId,
                FirstName = this.FirstName,
                Lastname = this.LastName,
                Email = this.Email,
                MiddleName = this.MiddleName,
                DateOfBirth = this.DateOfBirth
            };
        }

        public void Delete()
        {
            this.IsDeleted= true;
        }
        public void UnDelete()
        {
            this.IsDeleted= false; 
        }

        public void Update()
        {
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }

        public bool Equals(Person? other)
        {
            if (string.IsNullOrEmpty(this.SocialSecurityNumber) && !string.IsNullOrEmpty(other?.SocialSecurityNumber))
            {
                return this.SocialSecurityNumber == other.SocialSecurityNumber;
            }
            else
            {
                return this.PublicId == other?.PublicId;
            }
        }
    }
}
