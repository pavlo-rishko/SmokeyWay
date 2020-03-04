using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotNull().Length(50);
            RuleFor(e => e.LastName).NotNull().Length(100);
            RuleFor(e => e.DepartmentId).NotEqual(0);
            RuleFor(e => e.PhoneNumber).NotNull().Length(12, 15);
            RuleFor(e => e.PositionId).NotEqual(0);
            RuleFor(e => e.BirthDate).NotNull();
            RuleFor(e => e.GenderId).NotEqual(0);
        }
    }
}
