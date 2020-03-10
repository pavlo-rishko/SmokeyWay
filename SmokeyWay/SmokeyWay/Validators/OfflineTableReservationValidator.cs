using System;
using System.Data;
using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class OfflineTableReservationValidator : AbstractValidator<OfflineTableReservation>
    {
        public OfflineTableReservationValidator()
        {
            RuleFor(e => e.ClientName).Length(1, 45).NotEmpty();
            RuleFor(e => e.ClientPhoneNumber).Length(1, 45).NotEmpty();
            RuleFor(x => x.ReservationDateTime).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(e => e.EmployeeId).NotEqual(0).NotEmpty();
            RuleFor(x => x.TableId).NotEqual(0).NotEmpty();
        }
    }
}
