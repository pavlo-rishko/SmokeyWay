using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty().Length(1, 45);
            RuleFor(e => e.LastName).NotEmpty().Length(1, 45);
            RuleFor(e => e.DepartamentId).NotEqual(0).NotEmpty();
            RuleFor(e => e.PhoneNumber).NotEmpty().Length(1, 45);
            RuleFor(e => e.PositionId).NotEqual(0).NotEmpty();
            RuleFor(e => e.BirthDate).NotEmpty();
            RuleFor(e => e.GenderId).NotEqual(0).NotEmpty();
        }
    }
}
