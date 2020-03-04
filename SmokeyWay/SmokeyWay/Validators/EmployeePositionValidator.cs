using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class EmployeePositionValidator : AbstractValidator<EmployeePosition>
    {
        public EmployeePositionValidator()
        {
            RuleFor(e => e.Name).NotNull().Length(50);
            RuleFor(e => e.Description).Length(1000);
        }
    }
}
