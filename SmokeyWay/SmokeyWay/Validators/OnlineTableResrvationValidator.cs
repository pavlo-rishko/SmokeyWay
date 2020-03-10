using System;
using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class OnlineTableResrvationValidator : AbstractValidator<OnlineTableReservation>
    {
        public OnlineTableResrvationValidator()
        {
            RuleFor(x => x.ReservationDateTime).GreaterThanOrEqualTo(DateTime.Now).NotEmpty();
            RuleFor(x => x.TableId).NotEqual(0).NotEmpty();
            RuleFor(x => x.UserId).NotEqual(0).NotEmpty();
        }
    }
}
