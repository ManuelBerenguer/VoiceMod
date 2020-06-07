using System;
using System.Collections.Generic;
using System.Text;

namespace VoiceMod.Common.Messages
{
    /// <summary>
    /// Marker interface (pattern). Empty interface only to mark some objects as commands. Obj A "is a" ICommand. 
    /// A command represents the user intention to do something. Has imperative name (DoSomething).
    /// The commands mutates the state of the application creating or editing domain entities. 
    /// CQRS pattern
    /// We can use a message queue to enqueue the command.
    /// </summary>
    public interface ICommand
    { }

    public interface ICommand<T> : ICommand
    { }
}
