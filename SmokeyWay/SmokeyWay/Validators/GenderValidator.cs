using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class GenderValidator : AbstractValidator<Gender>
    {
        public GenderValidator()
        {
            RuleFor(e => e.Name).Length(30).NotNull();
            RuleFor(e => e.Descriprion).Length(500);
        }
    }
}
