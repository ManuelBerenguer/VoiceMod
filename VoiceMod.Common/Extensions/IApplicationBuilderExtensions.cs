using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using VoiceMod.Common.Middlewares;

namespace VoiceMod.Common.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
