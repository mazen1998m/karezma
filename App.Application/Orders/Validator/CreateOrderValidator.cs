using App.Application.Clints.Validator;
using App.Application.OrderProducts.Validator;
using App.Domain.Orders;
using App.Domain.Orders.Dtos;

namespace App.Application.Orders.Validator;

public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.Clint).SetValidator(new CreateClintDtoValidator());



        RuleFor(x => x.Address)
            .NotEmpty().WithMessage(OrderErrorMessage.AddressRequired)

            .MaximumLength(OrderConstraintProperty.AddressMaximumLength)
            .WithMessage(OrderErrorMessage.AddressMaximumLength)
            ;

        RuleFor(x => x.DeliveryFare)
            .GreaterThanOrEqualTo(OrderConstraintProperty.DeliveryFareMinimumValue)
            .WithMessage(OrderErrorMessage.DeliveryFareMinimumValue)
            ;

        RuleFor(x => x.Discount)
            .GreaterThanOrEqualTo(OrderConstraintProperty.DiscountMinimumValue)
            .WithMessage(OrderErrorMessage.DiscountMinimumValue)
            ;

        RuleFor(x => x.Notes)
            .MaximumLength(OrderConstraintProperty.NotesMaximumLength)
            .WithMessage(OrderErrorMessage.NotesMaximumLength)
            ;
        RuleFor(x => x.Products)
            .ForEach(x => x.SetValidator(new CreateOrderProductValidator()));



    }
}
