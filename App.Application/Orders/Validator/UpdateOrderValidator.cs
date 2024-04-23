using App.Domain.Orders.Dtos;
using FluentValidation;

namespace App.Application.Orders.Validator;

public class UpdateOrderValidator : AbstractValidator<UpdateOrderDto>
{
    public UpdateOrderValidator()
    {
        //RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        //RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer Id is required");
        //RuleFor(x => x.OrderItems).NotEmpty().WithMessage("Order Items is required");
        //RuleForEach(x => x.OrderItems).SetValidator(new OrderItemValidator());
    }
}
