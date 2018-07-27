using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Sigma.PatrimonioApi.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;


        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var type = exception.GetType();

            switch (type.ToString())
            {
                case "System.Net.HttpStatusCode.BadRequest":
                    code = HttpStatusCode.BadRequest;
                    break;
                case "System.Net.HttpStatusCode.NotFound":
                    code = HttpStatusCode.NotFound;
                    break;
                case "System.Net.HttpStatusCode.Unauthorized":
                    code = HttpStatusCode.Unauthorized;
                    break;
                case "System.Net.HttpStatusCode.ServiceUnavailable":
                    code = HttpStatusCode.ServiceUnavailable;
                    break;
                case "System.Data.ConstraintException":
                    code = HttpStatusCode.Conflict;
                    break;
                case "Sigma.PatrimonioApi.NotFoundException":
                    code = HttpStatusCode.NotFound;
                    break;
                case "Sigma.PatrimonioApi.ConstraintException":
                    code = HttpStatusCode.Conflict;
                    break;
            }

            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
