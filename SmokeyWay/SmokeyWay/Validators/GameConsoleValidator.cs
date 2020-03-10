using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class GameConsoleValidator : AbstractValidator<GameConsole>
    {
        public GameConsoleValidator()
        {
            RuleFor(x => x.GameConsoleTypeId).GreaterThan(0).NotEmpty();
        }
    }
}
