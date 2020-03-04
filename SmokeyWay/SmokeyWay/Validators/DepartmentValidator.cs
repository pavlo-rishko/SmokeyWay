using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(e => e.Name).Length(2, 150);
            RuleFor(e => e.Country).Length(2, 100);
            RuleFor(e => e.City).Length(2, 150);
            RuleFor(e => e.Street).Length(2, 200);
            RuleFor(e => e.HouseNumber).Length(1, 5);
        }
    }
}
