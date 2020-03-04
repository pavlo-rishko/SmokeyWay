using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class TableValidator : AbstractValidator<Table>
    {
        public TableValidator()
        {
            RuleFor(e => e.DepartmentId).NotEqual(0).NotNull();
            RuleFor(e => e.Identifier).Length(1, 45).NotNull();
            RuleFor(e => e.SeatingCapacity).InclusiveBetween(2, 10);         
        }
    }
}
