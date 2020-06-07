using System;
using System.Collections.Generic;
using System.Text;
using VoiceMod.Common.Messages;

namespace VoiceMod.Users.Core.Messages.Commands
{
    /// <summary>
    /// Represents the intention to delete an existing user.
    /// </summary>
    public class DeleteUser : ICommand
    {
        public Guid Id { get; set; }
    }
}
