using App.Domain.OrderProducts;
using App.Domain.OrderProducts.Dtos;

namespace App.Application.OrderProducts.Validator;

public class CreateOrderProductValidator : AbstractValidator<CreateOrderProductDto>
{
    public CreateOrderProductValidator()
    {

        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage(OrderProductErrorMessage.ProductIdRequired)
            ;

        RuleFor(x => x.Quantity)
            .GreaterThanOrEqualTo(OrderProductConstraintProperty.QuantityMinimumValue)
            .WithMessage(OrderProductErrorMessage.QuantityMinimumValue)
            ;

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(OrderProductConstraintProperty.PriceMinimumValue)
            .WithMessage(OrderProductErrorMessage.PriceMinimumValue)

            .LessThanOrEqualTo(OrderProductConstraintProperty.PriceMaximumValue)
            .WithMessage(OrderProductErrorMessage.PriceMaximumValue)
            ;


        RuleFor(x => x.Notes)
            .MaximumLength(OrderProductConstraintProperty.NotesMaximumLength)
            .WithMessage(OrderProductErrorMessage.NotesMaximumLength)
            ;
    }

}
