using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class DishValidator : AbstractValidator<Dish>
    {
        public DishValidator()
        {
            RuleFor(e => e.Name).Length(1, 45);
            RuleFor(e => e.Description).Length(1, 1000);
            RuleFor(e => e.Price).NotEqual(0);
            RuleFor(e => e.TypeId).NotEqual(0);
        }
    }
}
