using App.Domain.OrderProducts.Dtos;

namespace App.Application.OrderProducts.Validator;

public class UpdateOrderProductValidator : AbstractValidator<UpdateOrderProductDto>
{
    public UpdateOrderProductValidator()
    {
        //RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        //RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer Id is required");
        //RuleFor(x => x.OrderItems).NotEmpty().WithMessage("Order Items is required");
        //RuleForEach(x => x.OrderItems).SetValidator(new OrderItemValidator());
    }
}
