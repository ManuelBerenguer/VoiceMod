using System;
using System.Collections.Generic;
using System.Text;
using VoiceMod.Common.Entities;
using VoiceMod.Common.ValueObjects;

namespace VoiceMod.Users.Core.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public string Country { get; private set; }
        public Phone Phone { get; private set;}
        public PostalCode PostalCode { get; private set; }

        public User(EntityId entityId, string name, string surname, Email email, Password password, string country, Phone phone, PostalCode postalCode) : base(entityId) 
        {
            SetName(name);
            SetSurname(surname);
            SetCountry(country);
            SetEmail(email);
            SetPassword(password);
            SetPhone(phone);
            SetPostalCode(postalCode);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("the name of the user cannot be null or empty", nameof(name));

            Name = name;
        }

        public void SetSurname(string surname)
        {
            if (string.IsNullOrEmpty(surname))
                throw new ArgumentException("The surname of the user cannot be null or empty", nameof(surname));

            Surname = surname;
        }

        public void SetCountry(string country)
        {
            if (string.IsNullOrEmpty(country))
                throw new ArgumentException("The country for the user cannot be null or empty", nameof(Country));

            Country = country;
        }

        public void SetPassword(Password password)
        {
            Password = password;
        }

        public void SetEmail(Email email)
        {
            Email = email;
        }

        public void SetPhone(Phone phone)
        {
            Phone = phone;
        }

        public void SetPostalCode(PostalCode postalCode)
        {
            PostalCode = postalCode;
        }
    }
}
