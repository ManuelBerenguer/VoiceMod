﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoiceMod.Common.Dispatchers;
using VoiceMod.Common.Messages;
using VoiceMod.Common.Queries;

namespace VoiceMod.Users.Api.Controllers
{
    /// <summary>
    /// Shared things across all Controllers
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Dispatcher to dispatch commands or queries (CQRS). The commands or queries are handled immediately.
        /// </summary>
        private readonly IDispatcher _dispatcher;

        public BaseController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        /// <summary>
        /// Method to dispatch a query (CQRS read side)
        /// </summary>
        /// <typeparam name="TResult">Generic result type</typeparam>
        /// <param name="query">The query to be dispatched</param>
        /// <returns>Task of TResult</returns>
        protected async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
            => await _dispatcher.QueryAsync(query);

        /// <summary>
        /// Method to dispatch a command (CQRS write side)
        /// </summary>
        /// <typeparam name="TResult">Generic result type</typeparam>
        /// <param name="command">The command to be dispatched</param>
        /// <returns>Task of TResult</returns>
        protected async Task<TResult> SendAsync<TResult>(ICommand<TResult> command)
            => await _dispatcher.SendAsync(command);

        /// <summary>
        /// Method to dispatch a command (CQRS write side)
        /// </summary>
        /// <param name="command">The command to be dispatched</param>
        /// <returns>Task</returns>
        protected async Task SendAsync(ICommand command)
            => await _dispatcher.SendAsync(command);

        protected ActionResult<T> Single<T>(T data)
        {
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        protected ActionResult<IEnumerable<T>> Collection<T>(IEnumerable<T> result)
        {
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
