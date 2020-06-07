using System;
using System.Collections.Generic;
using System.Text;
using VoiceMod.Common.ValueObjects;
using VoiceMod.Users.Infrastructure.Data.EF.Persistance_Models;

namespace VoiceMod.Users.Infrastructure.Data.EF.Mappers
{
    public class UserMapper
    {
        public static User MapFrom(Core.Domain.Entities.User user)
        {
            return new User
            {
                Id = user.Id.Value(),
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email.Value(),
                Password = user.Password.Value(),
                Country = user.Country,
                Phone = user.Phone?.Value(),
                PostalCode = user.PostalCode?.Value()
            };
        }

        public static Core.Domain.Entities.User MapTo(User user)
        {
            return new Core.Domain.Entities.User(new EntityId(user.Id), user.Name, user.Surname, Email.FromString(user.Email),
                Password.FromHash(user.Password), user.Country, string.IsNullOrEmpty(user.Phone) ? null : Phone.FromString(user.Phone),
                string.IsNullOrEmpty(user.PostalCode) ? null : PostalCode.FromString(user.PostalCode));
        }
    }
}
