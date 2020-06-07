using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoiceMod.Common.Messages;
using VoiceMod.Common.Queries;

namespace VoiceMod.Common.Dispatchers
{
    public class Dispatcher : IDispatcher
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public Dispatcher(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        /// <summary>
        /// Dispatches a query
        /// </summary>        
        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
            => await _queryDispatcher.QueryAsync<TResult>(query);

        /// <summary>
        /// Dispatches a command expecting a result
        /// </summary>        
        public async Task<TResult> SendAsync<TResult>(ICommand<TResult> command)
            => await _commandDispatcher.SendAsync(command);

        /// <summary>
        /// Dispatches a command without expecting a result
        /// </summary>
        public async Task SendAsync(ICommand command)
            => await _commandDispatcher.SendAsync(command);
    }
}
