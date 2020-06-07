using System;
using System.Collections.Generic;
using System.Text;

namespace VoiceMod.Users.Core.Exceptions
{
    public class WrongPasswordException : ApplicationException
    {
        internal WrongPasswordException(string message) : base(message) { }
    }
}
