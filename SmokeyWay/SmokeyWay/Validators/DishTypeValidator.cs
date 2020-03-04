using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class DishTypeValidator : AbstractValidator<DishType>
    {
        public DishTypeValidator()
        {
            RuleFor(e => e.Name).Length(1, 45);            
        }
    }
}
