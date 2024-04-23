using App.Domain.Users.Dtos;

namespace App.Application.Users.Validator;

public class UsersValidator : AbstractValidator<CreateUserDto>
{
    public UsersValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("");
        RuleFor(x => x.Email).NotEmpty().WithMessage("");
        RuleFor(x => x.Email).EmailAddress().WithMessage("");
        RuleFor(x => x.Name).NotEmpty().WithMessage("");
    }
}
