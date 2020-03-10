using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class EmployeePositionValidator : AbstractValidator<EmployeePosition>
    {
        public EmployeePositionValidator()
        {
            RuleFor(e => e.Name).NotEmpty().Length(1, 45);
            RuleFor(e => e.Description).Length(8000);
        }
    }
}
