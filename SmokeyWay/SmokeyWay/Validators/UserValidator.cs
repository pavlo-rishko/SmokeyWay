using System;
using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(e => e.Name).Length(1, 45);
            RuleFor(e => e.PhoneNumber).Length(1, 13).NotEmpty();
            RuleFor(e => e.Email).NotEmpty().EmailAddress().Length(1, 45);
            RuleFor(e => e.BirthDate).NotEmpty().LessThan(DateTime.Now);
            RuleFor(e => e.GenderId).NotEqual(0).NotEmpty();
            RuleFor(e => e.CommunicationLanguage).Length(1, 45);
            RuleFor(e => e.RoleId).NotEqual(0).NotEmpty();
            RuleFor(e => e.PasswordHash).NotEmpty();
        }
    }
}
