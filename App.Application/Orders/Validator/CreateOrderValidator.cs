using App.Domain.Orders.Dtos;

namespace App.Application.Orders.Validator;

public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderValidator()
    {
        //RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer Id is required");
        //RuleFor(x => x.OrderItems).NotEmpty().WithMessage("Order Items is required");
        //RuleForEach(x => x.OrderItems).SetValidator(new OrderItemValidator());
    }
}
