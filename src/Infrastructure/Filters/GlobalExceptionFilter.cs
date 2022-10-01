using Domain.Common;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Net;

namespace Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();

            // Unknown exception
            var response = new ExceptionResponse
            {
                Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.6.1",
                Status = (int)HttpStatusCode.InternalServerError,
                Title = HttpStatusCode.InternalServerError.ToString(),
                Error = context.Exception.ToString(),
                TraceId = Activity.Current?.Id ?? context.HttpContext.TraceIdentifier
            };

            if (exceptionType.IsSubclassOf(typeof(BaseCustomException)))
            {
                response.Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.1";
                response.Title = "Bad request";
                response.Status = (int)HttpStatusCode.BadRequest;
            }
            else if(exceptionType == typeof(EntityNotFoundException))
            {
                response.Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.4";
                response.Title = "Not found";
                response.Status = (int)HttpStatusCode.NotFound;
            }

            context.HttpContext.Response.StatusCode = response.Status;
            context.Result = new ObjectResult(response);
            context.ExceptionHandled = true;
        }
    }

    public class ExceptionResponse
    {
        public string Type { get; set; } = null!;

        public string Title { get; set; } = null!;

        public int Status { get; set; }

        public string TraceId { get; set; } = null!;

        public string Error { get; set; } = null!;
    }
}
