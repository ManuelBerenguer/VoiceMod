using System;
using System.Collections.Generic;
using System.Text;
using VoiceMod.Common.Queries;
using VoiceMod.Users.Core.Dtos;

namespace VoiceMod.Users.Core.Queries
{
    public class GetUser : IQuery<UserDto>
    {
        public Guid Id { get; set; }
    }
}
