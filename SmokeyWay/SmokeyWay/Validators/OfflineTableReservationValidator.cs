using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class OfflineTableReservationValidator : AbstractValidator<OfflineTableReservation>
    {
        public OfflineTableReservationValidator()
        {
            RuleFor(e => e.UserName).Length(1, 45).NotNull();
            RuleFor(e => e.UserPhoneNumber).Length(1, 45).NotNull();            
        }
    }
}
