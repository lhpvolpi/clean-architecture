using CleanArchitecture.Core.Commands.User;
using CleanArchitecture.Core.Common.Extensions;
using FluentValidation;

namespace CleanArchitecture.Core.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(i => i.Email)
                .NotEmpty()
                    .WithMessage("e-mail is required")
                        .EmailAddress()
                            .WithMessage("e-mail invalid");

            RuleFor(i => i.Username)
                .NotEmpty()
                    .WithMessage("username is required");

            RuleFor(i => i.Password)
                .Password();
        }
    }
}

