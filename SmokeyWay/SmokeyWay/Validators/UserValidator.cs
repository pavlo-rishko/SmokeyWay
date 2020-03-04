using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(e => e.Name).Length(2, 100);
            RuleFor(e => e.PhoneNumber).Length(12, 15);
            RuleFor(e => e.Email).NotEmpty().EmailAddress().MaximumLength(110);
            RuleFor(e => e.BirthDate).NotNull();
            RuleFor(e => e.GenderId).NotEqual(0);
            RuleFor(e => e.CommunicationLanguage).Length(2, 30);
            RuleFor(e => e.RoleId).NotEqual(0);
            RuleFor(e => e.PasswordHash).NotNull();
        }
    }
}
