using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class DishValidator : AbstractValidator<Dish>
    {
        public DishValidator()
        {
            RuleFor(e => e.Name).Length(1, 45).NotEmpty();
            RuleFor(e => e.Description).Length(1, 1000);
            RuleFor(e => e.Price).LessThan(int.MaxValue).NotEmpty().GreaterThan(0);
            RuleFor(e => e.TypeId).NotEqual(0).NotEmpty();
            RuleFor(x => x.IsAvailable).NotEmpty();
        }
    }
}
