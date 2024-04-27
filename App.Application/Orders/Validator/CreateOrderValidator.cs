using App.Application.Clints.Validator;
using App.Domain.Orders.Dtos;

namespace App.Application.Orders.Validator;

public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.Clint).SetValidator(new CreateClintDroValidator());

        //RuleFor(x => x.OrderItems).NotEmpty().WithMessage("Order Items is required");
        //RuleForEach(x => x.OrderItems).SetValidator(new OrderItemValidator());
    }
}
