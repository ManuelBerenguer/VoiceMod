using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VoiceMod.Users.Infrastructure.Data.EF.Persistance_Models
{
    public class User : BaseEntity
    {
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

        public User() { }
    }
}
