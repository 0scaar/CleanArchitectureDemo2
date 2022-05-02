using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace NorthWind.WebExceptionsPresenter
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        readonly IDictionary<Type, IExceptionHandler> exceptionHandlers;

        public ApiExceptionFilterAttribute(IDictionary<Type, IExceptionHandler> exceptionHandlers)
        {
            this.exceptionHandlers = exceptionHandlers;
        }

        public override void OnException(ExceptionContext context)
        {
            Type exceptionType = context.Exception.GetType();

            if (exceptionHandlers.ContainsKey(exceptionType))
                exceptionHandlers[exceptionType].Handle(context);
            else
                new ExceptionHandlerBase().SetResult(context, StatusCodes.Status500InternalServerError, "An error occurred while processing the response.", "");

            base.OnException(context);
        }
    }
}
