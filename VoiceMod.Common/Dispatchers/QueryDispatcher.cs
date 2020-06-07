using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoiceMod.Common.Handlers;
using VoiceMod.Common.Queries;

namespace VoiceMod.Common.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Dispatches a new query finding the correct query handler and calling it's handle method to handle the query dispatched
        /// </summary>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="query">query to be dispatched</param>
        /// <returns>Task the will provide the result</returns>
        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            // We get the type of the query
            Type queryType = query.GetType();

            // We build the type of the query handler necessary for the query type
            // Dynamic objects expose members such as properties and methods at runtime, instead of compile time
            // This enables you to create objects to work with structures that do not match a static type or format
            Type queryHandlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, typeof(TResult));

            // We get instance of that query handler type from the DI container
            dynamic queryHandler = _serviceProvider.GetRequiredService(queryHandlerType);

            // We call the query handler
            var data = await queryHandler.HandleAsync((dynamic)query);

            return data;
        }
    }
}
