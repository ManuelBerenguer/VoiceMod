using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoiceMod.Common.Extensions;
using VoiceMod.Common.Messages;

namespace VoiceMod.Common.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Dispatches a new command finding the correct command handler and calling it's handle method to handle the command dispatched
        /// </summary>
        /// <typeparam name="TResult">Generic type of the result</typeparam>
        /// <param name="command">Command to be dispatched</param>
        /// <returns>Task of generic result type </returns>
        public async Task<TResult> SendAsync<TResult>(ICommand<TResult> command)
        {
            // We get an instance of the command handler suppossed to handle the command type
            dynamic commandHandler = command.GetCommandHandler(_serviceProvider);

            // We run the command handler
            var result = await commandHandler.HandleAsync((dynamic)command);

            return result;
        }

        /// <summary>
        /// Dispatches a new command finding the correct command handler and calling it's handle method to handle the command dispatched
        /// </summary>
        /// <param name="command">Command to be dispatched</param>
        public async Task SendAsync(ICommand command)
        {
            // We get an instance of the command handler suppossed to handle the command type
            dynamic commandHandler = command.GetCommandHandler(_serviceProvider);

            // We run the command handler
            await commandHandler.HandleAsync((dynamic)command);
        }
    }
}
