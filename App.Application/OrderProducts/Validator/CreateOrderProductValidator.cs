using App.Domain.OrderProducts.Dtos;

namespace App.Application.OrderProducts.Validator;

public class CreateOrderProductValidator : AbstractValidator<CreateOrderProductDto>
{
    public CreateOrderProductValidator()
    {
        //RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer Id is required");
        //RuleFor(x => x.OrderItems).NotEmpty().WithMessage("Order Items is required");
        //RuleForEach(x => x.OrderItems).SetValidator(new OrderItemValidator());
    }
}
