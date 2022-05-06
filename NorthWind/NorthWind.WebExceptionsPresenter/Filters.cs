using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Entities.Exceptions;
using System;
using System.Collections.Generic;

namespace NorthWind.WebExceptionsPresenter
{
    public static class Filters
    {
        public static void Register(MvcOptions options)
        {
            options.Filters.Add(new ApiExceptionFilterAttribute(
                new Dictionary<Type, IExceptionHandler>
                {
                    { typeof(GeneralException), new GeneralExceptionHandler() },
                    { typeof(ValidationException), new ValidationExceptionHandler() }
                }));
        }
    }
}
