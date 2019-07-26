using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2.Middleware
{
    public class SampleMiddleware
    {
        private readonly RequestDelegate next;

        public SampleMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var originalRequestBody = context.Request.ContentType;

            Console.WriteLine("Before execute the 'next' delegate.");

            await this.next(context);

            Console.WriteLine("Response incoming");
        }
    }
}
