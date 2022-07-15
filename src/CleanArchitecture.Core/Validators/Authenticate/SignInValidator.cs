using CleanArchitecture.Core.Commands.Authenticate;
using FluentValidation;

namespace CleanArchitecture.Core.Validators.Authenticate
{
    public class SignInValidator : AbstractValidator<SignInCommand>
    {
        public SignInValidator()
        {
            RuleFor(i => i.Username)
                .NotEmpty()
                    .WithMessage("username is required");

            RuleFor(i => i.Password)
                .NotEmpty()
                    .WithMessage("password is required");
        }
    }
}

