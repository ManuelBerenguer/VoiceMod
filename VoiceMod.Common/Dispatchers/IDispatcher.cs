using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoiceMod.Common.Messages;
using VoiceMod.Common.Queries;

namespace VoiceMod.Common.Dispatchers
{
    /// <summary>
    /// Type use to dispatch commands or queries
    /// </summary>
    public interface IDispatcher
    {
        /// <summary>
        /// Dispatch a command expecting a result
        /// </summary>
        Task<TResult> SendAsync<TResult>(ICommand<TResult> command);

        /// <summary>
        /// Dispatch a command without expecting any result
        /// </summary>
        Task SendAsync(ICommand command);

        /// <summary>
        /// Dispatch a query
        /// </summary>
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
