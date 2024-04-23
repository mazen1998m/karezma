using App.Application.Const;
using App.Application.Users.ResetUserPassword.Validator;
using App.Domain.Representatives.Dtos;
using App.Domain.Users;

namespace App.Application.Representatives.Validator;

public class RepresentativeCreateValidator : AbstractValidator<RepresentativeCreateDto>
{
    public IService<User> _userService { get; set; }

    public RepresentativeCreateValidator()
    {
        #region UserName

        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage(RepresentativeErrorMessage.UserNameRequired);//ar en

        RuleFor(x => x.UserName)
            .Must(IsUserNameUnique)
            .WithMessage(RepresentativeErrorMessage.UsernameIsUesd);

        RuleFor(x => x.UserName)
            .MaximumLength(ConstraintProperty.UserNameMaximumLength)
            .WithMessage(RepresentativeErrorMessage.UsernameMaximumLength);

        RuleFor(x => x.UserName)
            .MinimumLength(ConstraintProperty.UserNameMinimumLength)
            .WithMessage(RepresentativeErrorMessage.UsernameMinimumLength);

        #endregion

        #region Password
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(ResePasswordErrorMessage.PasswordRequired);

        RuleFor(x => x.Password)
            .MinimumLength(ConstraintProperty.PasswordMinimumLength)
            .WithMessage(ResePasswordErrorMessage.PasswordMinimumLength);

        RuleFor(x => x.Password)
            .MaximumLength(ConstraintProperty.PasswordMaximumLength)
            .WithMessage(ResePasswordErrorMessage.PasswordMaximumLength);

        RuleFor(x => x.Password)
            .Matches(ConstraintProperty.PasswordMatches)
            .WithMessage(ResePasswordErrorMessage.PasswordFormat);

        #endregion

        #region Name

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(RepresentativeErrorMessage.NameRequired);

        RuleFor(x => x.Name)
           .MaximumLength(ConstraintProperty.NameMaximumLength)
           .WithMessage(RepresentativeErrorMessage.NameMaximumLength);

        RuleFor(x => x.Name)
            .MinimumLength(ConstraintProperty.NameMinimumLength)
            .WithMessage(RepresentativeErrorMessage.NameMinimumLength);

        #endregion

        #region Phone

        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage(RepresentativeErrorMessage.PhoneRequired);

        RuleFor(x => x.Phone)
            .Matches(ConstraintProperty.PhoneMatches)
            .WithMessage(RepresentativeErrorMessage.PhoneMatches);

        RuleFor(x => x.Phone)
            .Length(ConstraintProperty.PhoneLength)
            .WithMessage(RepresentativeErrorMessage.PhoneLength);

        #endregion

        #region Commision
        RuleFor(x => x.Commision)
            .GreaterThanOrEqualTo(ConstraintProperty.CommisionMinimum)
            .WithMessage(RepresentativeErrorMessage.CommisionMinimum);
        #endregion
    }


    public bool IsUserNameUnique(string userName)
    {
        _userService = _userService.Inject();
        return _userService.Any(x => x.Email == userName) == 0;
    }
}
