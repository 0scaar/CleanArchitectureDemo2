using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionsPresenter
{
    public class ExceptionHandlerBase
    {
        readonly Dictionary<int, string> RTF7231Types = new Dictionary<int, string>
        {
            {
                StatusCodes.Status500InternalServerError, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
            },
            {
                StatusCodes.Status400BadRequest, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4"
            },
        };

        public Task SetResult(ExceptionContext context, int? status, string title, string detail)
        {
            var details = new ProblemDetails
            {
                Status = status,
                Title = title,
                Type = RTF7231Types.ContainsKey(status.Value) ? RTF7231Types[status.Value] : "",
                Detail = detail
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = status
            };

            context.ExceptionHandled = true;

            return Task.CompletedTask;
        }
    }
}
