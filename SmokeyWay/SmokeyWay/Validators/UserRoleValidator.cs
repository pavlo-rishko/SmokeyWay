﻿using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class UserRoleValidator : AbstractValidator<UserRole>
    {
        public UserRoleValidator()
        {
            RuleFor(e => e.Id).NotNull();
            RuleFor(x => x.Name).Length(5, 40);
        }
    }
}