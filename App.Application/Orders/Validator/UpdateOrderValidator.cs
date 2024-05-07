using App.Application.Clints.Validator;
using App.Application.OrderProducts.Validator;
using App.Domain.Orders;
using App.Domain.Orders.Dtos;

namespace App.Application.Orders.Validator;

public class UpdateOrderValidator : AbstractValidator<UpdateOrderDto>
{
    private IRepository<Order> _repository { get; set; }

    public UpdateOrderValidator()
    {

        RuleFor(x => x.Id).Must(CanUpdate).WithMessage(OrderErrorMessage.CanNotUpdate);

        RuleFor(x => x.Clint).SetValidator(new UpdateClintDtoValidator());

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
            .ForEach(x => x.SetValidator(new UpdateOrderProductValidator()));

    }

    public bool CanUpdate(int id)
    {
        var repository = _repository.Inject();
        var orderStatus = repository.FirstOrDefault(x => x.Id == id, c => c.OrderStatus);
        if (orderStatus == OrderStatus.Pending || orderStatus == OrderStatus.Reject)
        {
            return false;
        }
        return true;
    }
}
