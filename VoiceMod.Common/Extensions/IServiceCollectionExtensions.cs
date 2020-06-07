using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using VoiceMod.Common.Dispatchers;

namespace VoiceMod.Common.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDispatchers(this IServiceCollection services)
        {
            services.AddTransient<IDispatcher, Dispatcher>();
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            services.AddTransient<IQueryDispatcher, QueryDispatcher>();
        }
    }
}
