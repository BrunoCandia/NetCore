using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2.Middleware
{
    public class LogRequestMiddleware
    {
        private readonly RequestDelegate next;
        private readonly TelemetryClient telemetryClient;

        public LogRequestMiddleware(RequestDelegate next)
        {
            this.next = next;
            this.telemetryClient = new TelemetryClient();
        }

        public async Task Invoke(HttpContext context)
        {
            var requestBodyStream = new MemoryStream();
            var originalRequestBody = context.Request.Body;

            await context.Request.Body.CopyToAsync(requestBodyStream);
            requestBodyStream.Seek(0, SeekOrigin.Begin);

            var url = UriHelper.GetDisplayUrl(context.Request);
            var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();

            requestBodyStream.Seek(0, SeekOrigin.Begin);
            context.Request.Body = requestBodyStream;

            await this.next(context);
            context.Request.Body = originalRequestBody;

            Tracerequest(requestBodyText, url, context.Request.Method);
        }

        private void Tracerequest(string payload, string url, string method)
        {
            var telemetry = new TraceTelemetry(url);

            telemetry.Properties.Add("Body", payload);
            telemetry.Properties.Add("Method", method);

            this.telemetryClient.TrackTrace(telemetry);
        }
    }
}
