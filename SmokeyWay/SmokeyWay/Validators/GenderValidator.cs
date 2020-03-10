using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class GenderValidator : AbstractValidator<Gender>
    {
        public GenderValidator()
        {
            RuleFor(e => e.Name).Length(1, 45).NotEmpty();
            RuleFor(e => e.Descriprion).Length(1000);
        }
    }
}
