using FluentValidation;
using System.Linq;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderInputPort>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.RequestData.CustomerId)
                .NotEmpty().WithMessage("You must provide the client identifier");

            RuleFor(c => c.RequestData.ShipAddress)
                .NotEmpty().WithMessage("You must provide the shipping address");

            RuleFor(c => c.RequestData.ShipCity)
                .NotEmpty()
                .MinimumLength(3).WithMessage("You must provide at least 3 characters of the city name");

            RuleFor(c => c.RequestData.ShipCountry)
                .NotEmpty()
                .MinimumLength(3).WithMessage("You must provide at least 3 characters of the country name");

            RuleFor(c => c.RequestData.OrderDetails)
                .Must(d => d != null && d.Any()).WithMessage("The products of the order must be specified");
        }
    }
}
