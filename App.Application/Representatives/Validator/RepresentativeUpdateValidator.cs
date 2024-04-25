using App.Domain.Representatives;
using App.Domain.Representatives.Dtos;
using App.Domain.Users;

namespace App.Application.Representatives.Validator;

public class RepresentativeUpdateValidator : AbstractValidator<UpdateRepresentativeDto>
{
    public IService<User> _userService { get; set; }
    public int UserId { get; set; }

    public RepresentativeUpdateValidator()
    {
        #region UserName

        RuleFor(x => x.UserId).Must(SetUserId);

        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage(RepresentativeErrorMessage.UserNameRequired);

        RuleFor(x => x.UserName)
            .Must(IsUserNameUnique)
            .WithMessage(RepresentativeErrorMessage.UsernameIsUesd);

        RuleFor(x => x.UserName)
            .MaximumLength(RepresentativeConstraintProperty.UserNameMaximumLength)
            .WithMessage(RepresentativeErrorMessage.UsernameMaximumLength);

        RuleFor(x => x.UserName)
            .MinimumLength(RepresentativeConstraintProperty.UserNameMinimumLength)
            .WithMessage(RepresentativeErrorMessage.UsernameMinimumLength);

        #endregion


        #region Name

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(RepresentativeErrorMessage.NameRequired);

        RuleFor(x => x.Name)
           .MaximumLength(RepresentativeConstraintProperty.NameMaximumLength)
           .WithMessage(RepresentativeErrorMessage.NameMaximumLength);

        RuleFor(x => x.Name)
            .MinimumLength(RepresentativeConstraintProperty.NameMinimumLength)
            .WithMessage(RepresentativeErrorMessage.NameMinimumLength);

        #endregion

        #region Phone

        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage(RepresentativeErrorMessage.PhoneRequired);

        RuleFor(x => x.Phone)
            .Matches(RepresentativeConstraintProperty.PhoneFormat)
            .WithMessage(RepresentativeErrorMessage.PhoneFormat);

        RuleFor(x => x.Phone)
            .Length(RepresentativeConstraintProperty.PhoneLength)
            .WithMessage(RepresentativeErrorMessage.PhoneLength);

        #endregion

        #region Commision
        RuleFor(x => x.Commision)
            .GreaterThanOrEqualTo(RepresentativeConstraintProperty.CommisionMinimum)
            .WithMessage(RepresentativeErrorMessage.CommisionMinimum);
        #endregion
    }


    public bool IsUserNameUnique(string userName)
    {
        _userService = _userService.Inject();
        var oldUserName = _userService.FirstOrDefault(user => user.Id == UserId, u => new { u.Id, u.Email }).Response.Email;

        return _userService.Any(x => x.Email == userName && x.Email != oldUserName) == 0;
    }

    public bool SetUserId(int userId)
    {
        UserId = userId;
        return true;
    }
}
