using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class UserRoleValidator : AbstractValidator<UserRole>
    {
        public UserRoleValidator()
        {
            RuleFor(x => x.Name).Length(1, 45);
        }
    }
}