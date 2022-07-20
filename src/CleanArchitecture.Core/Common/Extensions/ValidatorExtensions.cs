using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;

namespace CleanArchitecture.Core.Common.Extensions
{
    public static class ValidatorExtensions
    {
        public static List<KeyValuePair<string, string>> ToListKeyValuePair(this List<ValidationFailure> errors)
            => errors.Select(i => new KeyValuePair<string, string>(i.PropertyName, i.ErrorMessage)).ToList();

        public static IRuleBuilder<T, string> PasswordValidator<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength = 14)
            => ruleBuilder
                .NotEmpty()
                    .WithMessage("password is required")
                .MinimumLength(minimumLength)
                    .WithMessage($"password must contain at least {minimumLength} characters")
                .Matches("[A-Z]")
                    .WithMessage("password must contain uppercase letters")
                .Matches("[a-z]")
                    .WithMessage("password must contain lowercase letters")
                .Matches("[0-9]")
                    .WithMessage("password must contain digits")
                .Matches("[^a-zA-Z0-9]")
                    .WithMessage("password must contain special character");

        public static IRuleBuilder<T, string> EmailValidator<T>(this IRuleBuilder<T, string> ruleBuilder)
            => ruleBuilder
                .NotEmpty()
                    .WithMessage("e-mail is required")
                .EmailAddress()
                    .WithMessage("e-mail invalid");
    }
}

