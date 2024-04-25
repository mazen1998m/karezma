using App.Application.Users.ResetUserPassword.Validator;
using App.Domain.Representatives;
using App.Domain.Representatives.Dtos;
using App.Domain.Users;

namespace App.Application.Representatives.Validator;

public class RepresentativeCreateValidator : AbstractValidator<CreateRepresentativeDto>
{
    public IService<User> _userService { get; set; }

    public RepresentativeCreateValidator()
    {
        #region UserName

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage(RepresentativeErrorMessage.UserNameRequired)

            .Must(IsUserNameUnique).WithMessage(RepresentativeErrorMessage.UsernameIsUesd)

            .MaximumLength(RepresentativeConstraintProperty.UserNameMaximumLength).WithMessage(RepresentativeErrorMessage.UsernameMaximumLength)

            .MinimumLength(RepresentativeConstraintProperty.UserNameMinimumLength).WithMessage(RepresentativeErrorMessage.UsernameMinimumLength);

        #endregion

        #region Password

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(ResePasswordErrorMessage.PasswordRequired)

            .MinimumLength(ResePasswordConstraintProperty.PasswordMinimumLength).WithMessage(ResePasswordErrorMessage.PasswordMinimumLength)

            .MaximumLength(ResePasswordConstraintProperty.PasswordMaximumLength).WithMessage(ResePasswordErrorMessage.PasswordMaximumLength)

            .Matches(ResePasswordConstraintProperty.PasswordFormat).WithMessage(ResePasswordErrorMessage.PasswordFormat);

        #endregion

        #region Name

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(RepresentativeErrorMessage.NameRequired)

            .MaximumLength(RepresentativeConstraintProperty.NameMaximumLength).WithMessage(RepresentativeErrorMessage.NameMaximumLength)

            .MinimumLength(RepresentativeConstraintProperty.NameMinimumLength).WithMessage(RepresentativeErrorMessage.NameMinimumLength);

        #endregion

        #region Phone

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage(RepresentativeErrorMessage.PhoneRequired)

            .Matches(RepresentativeConstraintProperty.PhoneFormat).WithMessage(RepresentativeErrorMessage.PhoneFormat)

            .Length(RepresentativeConstraintProperty.PhoneLength).WithMessage(RepresentativeErrorMessage.PhoneLength);

        #endregion

        #region Commision
        RuleFor(x => x.Commision)
            .GreaterThanOrEqualTo(RepresentativeConstraintProperty.CommisionMinimum).WithMessage(RepresentativeErrorMessage.CommisionMinimum);
        #endregion
    }


    private bool IsUserNameUnique(string userName)
    {
        _userService = _userService.Inject();
        return _userService.Any(x => x.Email == userName) == 0;
    }
}
