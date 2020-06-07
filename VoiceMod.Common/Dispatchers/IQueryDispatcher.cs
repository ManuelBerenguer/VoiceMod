using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoiceMod.Common.Queries;

namespace VoiceMod.Common.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
