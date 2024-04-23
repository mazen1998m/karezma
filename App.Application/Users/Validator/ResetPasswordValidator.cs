using App.Domain.Users.Auths;

namespace App.Application.Users.Validator;

public class ResetPasswordValidator : AbstractValidator<ResetPassword>
{
    public ResetPasswordValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("");
        RuleFor(x => x.NewPassword).NotEmpty().WithMessage("");
    }
}
