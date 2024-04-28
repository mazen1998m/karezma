using App.Domain.Clints;
using App.Domain.Clints.Dtos;

namespace App.Application.Clints.Validator;

public class CreateClintDtoValidator : AbstractValidator<CreateClintDto>
{
    public CreateClintDtoValidator()
    {

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

            .Length(ClintConstraintProperty.SecandPhoneLength).WithMessage(ClintErrorMessage.SecandPhoneLength);

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
}
