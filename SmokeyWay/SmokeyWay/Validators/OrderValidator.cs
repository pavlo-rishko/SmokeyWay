using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.TableId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.EmployeeId).NotEmpty().GreaterThan(0);
        }
    }
}
