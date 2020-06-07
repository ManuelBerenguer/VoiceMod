using System;
using System.Collections.Generic;
using System.Text;
using VoiceMod.Common.Exceptions;

namespace VoiceMod.Users.Core.Exceptions
{
    public class UserNotFoundException : EntityNotFoundException
    {
        internal UserNotFoundException(string message) : base(message) { }
    }
}
