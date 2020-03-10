using System;
using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class OnlineTableResrvationValidator : AbstractValidator<OnlineTableReservation>
    {
        public OnlineTableResrvationValidator()
        {
            RuleFor(x => x.ReservationDateTime).GreaterThanOrEqualTo(DateTime.Now);
        }
    }
}
