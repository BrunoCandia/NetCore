using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2.Middleware
{
    public static class SampleMiddlewareExtension
    {
        public static IApplicationBuilder UseSampleMiddlewareExtension(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SampleMiddleware>();
        }
    }
}
