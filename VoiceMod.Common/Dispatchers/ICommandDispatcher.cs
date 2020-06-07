using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoiceMod.Common.Messages;

namespace VoiceMod.Common.Dispatchers
{
    public interface ICommandDispatcher
    {
        Task<TResult> SendAsync<TResult>(ICommand<TResult> command);
        Task SendAsync(ICommand command);
    }
}
