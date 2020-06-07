using System;
using System.Collections.Generic;
using System.Text;

namespace VoiceMod.Users.Core.Exceptions
{
    public class EmailAlreadyInUseException : ApplicationException
    {
        internal EmailAlreadyInUseException(string message) : base(message) { }
    }
}
