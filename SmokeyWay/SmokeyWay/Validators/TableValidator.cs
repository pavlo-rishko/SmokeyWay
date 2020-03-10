using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class TableValidator : AbstractValidator<Table>
    {
        public TableValidator()
        {
            RuleFor(e => e.DepartamentId).NotEqual(0).NotEmpty();
            RuleFor(e => e.Identifier).Length(1, 45).NotEmpty();
            RuleFor(e => e.SeatingCapacity).InclusiveBetween(1, 10).NotEmpty();
            RuleFor(x => x.GameConsoleId).NotEqual(0).NotEmpty();
        }
    }
}
