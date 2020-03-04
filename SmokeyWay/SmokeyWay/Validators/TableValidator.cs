using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class TableValidator :AbstractValidator<Table>
    {
        TableValidator()
        {
            RuleFor(e => e.DepartmentId).NotEqual(0);
            RuleFor(e => e.Identifier).Length(1, 10).NotNull();
            RuleFor(e => e.SeatingCapacity).InclusiveBetween(2, 10);         
        }
    }
}
