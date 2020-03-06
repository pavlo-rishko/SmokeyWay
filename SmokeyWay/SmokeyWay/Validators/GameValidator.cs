using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {
            RuleFor(e => e.Name).Length(1, 45);
            RuleFor(e => e.Description).Length(1, 1000);
            RuleFor(e => e.LicenseBeginDate).NotNull();
            RuleFor(e => e.LicenseEndDate).NotNull();
        }
    }
}
