using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(e => e.Name).Length(1, 45);
            RuleFor(e => e.Country).Length(1, 45);
            RuleFor(e => e.City).Length(1, 45);
            RuleFor(e => e.Street).Length(1, 45);
            RuleFor(e => e.HouseNumber).Length(1, 5);
        }
    }
}
