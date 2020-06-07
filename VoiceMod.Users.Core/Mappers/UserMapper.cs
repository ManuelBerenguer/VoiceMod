using System;
using System.Collections.Generic;
using System.Text;
using VoiceMod.Users.Core.Domain.Entities;
using VoiceMod.Users.Core.Dtos;

namespace VoiceMod.Users.Core.Mappers
{
    public class UserMapper
    {
        public static UserDto From(User user)
        {
            return new UserDto
            {
                Id = user.Id.Value(),
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email.Value(),
                Country = user.Country,
                Phone = user.Phone?.Value(),
                PostalCode = user.PostalCode?.Value()
            };
        }
    }
}
