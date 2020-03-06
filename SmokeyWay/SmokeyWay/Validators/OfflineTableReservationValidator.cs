using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class OfflineTableReservationValidator : AbstractValidator<OfflineTableReservation>
    {
        public OfflineTableReservationValidator()
        {
            RuleFor(e => e.ClientName).Length(1, 45).NotNull();
            RuleFor(e => e.ClientPhoneNumber).Length(1, 45).NotNull();
            RuleFor(e => e.EmployeeId).NotEqual(0);
        }
    }
}
