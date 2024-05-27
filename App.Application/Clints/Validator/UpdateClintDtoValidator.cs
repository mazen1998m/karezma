using App.Domain.Clints;
using App.Domain.Clints.Dtos;

namespace App.Application.Clints.Validator;

public class UpdateClintDtoValidator : AbstractValidator<UpdateClintDto>
{
    private IRepository<Clint> _repository { get; set; }
    public UpdateClintDtoValidator()
    {

        #region Id

        //RuleFor(x => x.Id).Must(CanUpdate).WithMessage(ClintErrorMessage.CanNotUpdate);

        #endregion
        #region Name

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ClintErrorMessage.NameRequired)

            .MaximumLength(ClintConstraintProperty.NameMaximumLength).WithMessage(ClintErrorMessage.NameMaximumLength)

            .MinimumLength(ClintConstraintProperty.NameMinimumLength).WithMessage(ClintErrorMessage.NameMinimumLength);

        #endregion 

        #region Phone

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage(ClintErrorMessage.PhoneRequired)

            .Matches(ClintConstraintProperty.PhoneFormat).WithMessage(ClintErrorMessage.PhoneFormat)

            .Length(ClintConstraintProperty.PhoneLength).WithMessage(ClintErrorMessage.PhoneLength);

        #endregion

        #region SecandPhone

        RuleFor(x => x.SecandPhone)
            .Matches(ClintConstraintProperty.SecandPhoneFormat).WithMessage(ClintErrorMessage.SecandPhoneFormat)
            .When(x => !string.IsNullOrEmpty(x.SecandPhone))
            .Length(ClintConstraintProperty.SecandPhoneLength).WithMessage(ClintErrorMessage.SecandPhoneLength)
            .When(x => !string.IsNullOrEmpty(x.SecandPhone))
            ;
        #endregion

        #region Weight

        RuleFor(x => x.Weight)
            .GreaterThanOrEqualTo(ClintConstraintProperty.WeightMinimum).WithMessage(ClintErrorMessage.WeightMinimum);

        #endregion

        #region Hight

        RuleFor(x => x.Hight)
            .GreaterThanOrEqualTo(ClintConstraintProperty.HightMinimum).WithMessage(ClintErrorMessage.HightMinimum);

        #endregion


    }

    //public bool CanUpdate(int id)
    //{
    //    var repository = _repository.Inject();
    //    var orderStatus = repository.FirstOrDefault(x => x.Id == id, c => c.Order.OrderStatus);
    //    if (orderStatus == OrderStatus.Pending || orderStatus == OrderStatus.Reject)
    //    {
    //        return true;
    //    }
    //    return false;
    //}
}
