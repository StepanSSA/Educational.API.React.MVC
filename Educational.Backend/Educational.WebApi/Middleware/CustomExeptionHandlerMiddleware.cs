using FluentValidation;
using System.Net;
using System.Text.Json;
using Educational.Application.Common.Exeptions;

namespace Educational.WebApi.Middleware
{
    public class CustomExeptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public CustomExeptionHandlerMiddleware(RequestDelegate next)
        {
            this.next=next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExeptionAsync(context, ex);
            }
        }

        private Task HandleExeptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch(ex)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundExeption:
                    code = HttpStatusCode.NotFound;
                    break;

            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if(result == string.Empty) 
            {
                result = JsonSerializer.Serialize(new {error = ex.Message});
            }

            return context.Response.WriteAsync(result);
        }
    }
}
