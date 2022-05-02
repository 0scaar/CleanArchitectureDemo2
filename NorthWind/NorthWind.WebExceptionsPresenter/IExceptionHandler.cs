using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionsPresenter
{
    public interface IExceptionHandler
    {
        Task Handle(ExceptionContext context);
    }
}
