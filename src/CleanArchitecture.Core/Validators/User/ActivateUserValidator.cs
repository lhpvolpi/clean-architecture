using CleanArchitecture.Core.Commands.User;
using CleanArchitecture.Core.Common.Extensions;
using FluentValidation;

namespace CleanArchitecture.Core.Validators.User
{
    public class ActivateUserValidator : AbstractValidator<ActivateUserCommand>
    {
        public ActivateUserValidator()
        {
            RuleFor(i => i.Email)
                .EmailValidator();
        }
    }
}

