using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VoiceMod.Common.Messages;
using VoiceMod.Users.Core.Dtos;

namespace VoiceMod.Users.Core.Messages.Commands
{
    public class AuthenticateUser : ICommand<UserDto>
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public AuthenticateUser(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
