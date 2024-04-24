using App.Domain.Users.Auths;

namespace App.Application.Users.ResetUserPassword.Validator;

public class ResetPasswordValidator : AbstractValidator<ResetPassword>
{
    public ResetPasswordValidator()
    {

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .WithMessage(ResePasswordErrorMessage.PasswordRequired);

        RuleFor(x => x.NewPassword)
            .MinimumLength(ResePasswordConstraintProperty.PasswordMinimumLength)
            .WithMessage(ResePasswordErrorMessage.PasswordMinimumLength);

        RuleFor(x => x.NewPassword)
            .MaximumLength(ResePasswordConstraintProperty.PasswordMaximumLength)
            .WithMessage(ResePasswordErrorMessage.PasswordMaximumLength);

        RuleFor(x => x.NewPassword)
            .Matches(ResePasswordConstraintProperty.PasswordMatches)
            .WithMessage(ResePasswordErrorMessage.PasswordFormat);

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.NewPassword)
            .WithMessage(ResePasswordErrorMessage.PasswordsDoNotMatch);



    }
}
