using CleanArchitecture.Core.Commands.User;
using CleanArchitecture.Core.Common.Extensions;
using FluentValidation;

namespace CleanArchitecture.Core.Validators.User
{
    public class InactivateUserValidator : AbstractValidator<InactivateUserCommand>
    {
        public InactivateUserValidator()
        {
            RuleFor(i => i.Email)
                .EmailValidator();
        }
    }
}

