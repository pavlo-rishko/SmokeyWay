using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class GameConsoleTypeValidator : AbstractValidator<GameConsoleType>
    {
        public GameConsoleTypeValidator()
        {
            RuleFor(x => x.Name).Length(1, 45);
        }
    }
}
