using System;
using CleanArchitecture.Core.Commands.User;
using CleanArchitecture.Core.Common.Extensions;
using FluentValidation;

namespace CleanArchitecture.Core.Validators.User
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(i => i.Id)
                .NotEqual(Guid.Empty)
                    .WithMessage("id is required");

            RuleFor(i => i.Email)
                .EmailValidator();

            RuleFor(i => i.Username)
                .NotEmpty()
                    .WithMessage("username is required");
        }
    }
}

