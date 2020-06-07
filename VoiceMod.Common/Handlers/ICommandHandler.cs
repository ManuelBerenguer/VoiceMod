using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoiceMod.Common.Messages;

namespace VoiceMod.Common.Handlers
{
    /// <summary>
    /// Prototype for any command handler built following the Command Query Responsability Segregation (CQRS).
    /// </summary>
    /// <typeparam name="TCommand">Command to handle</typeparam>
    /// <typeparam name="TResult">Result Type</typeparam>
    public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
        Task<TResult> HandleAsync(TCommand command);
    }

    /// <summary>
    /// Prototype for any command handler built following the Command Query Responsability Segregation (CQRS).
    /// </summary>
    /// <typeparam name="TCommand">Command to handle</typeparam>
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
