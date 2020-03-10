using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {
            RuleFor(e => e.Name).Length(1, 45).NotEmpty();
            RuleFor(e => e.Description).Length(1, 1000);
            RuleFor(e => e.LicenseBeginDate).NotEmpty();
            RuleFor(e => e.LicenseEndDate).NotEmpty();
        }
    }
}
