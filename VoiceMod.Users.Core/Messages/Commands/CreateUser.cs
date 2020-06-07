using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using VoiceMod.Common.Messages;
using VoiceMod.Users.Core.Dtos;

namespace VoiceMod.Users.Core.Messages.Commands
{
    /// <summary>
    /// Represents the intention to create a new user.
    /// </summary>
    public class CreateUser : ICommand<UserDto>
    {
        public Guid Id { get; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Country { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }

        public CreateUser(Guid id, string name, string surname, string email, string password, string country, string phone, string postalCode)
        {
            Id = (id == null || id == Guid.Empty) ? Guid.NewGuid() : id;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Country = country;
            Phone = phone;
            PostalCode = postalCode;
        }
    }
}
