using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace CleanArchitecture.Core.Common.Extensions
{
    public static class ValidatorExtensions
    {
        public static List<KeyValuePair<string, string>> ToListKeyValuePair(this List<ValidationFailure> errors)
            => errors.Select(i => new KeyValuePair<string, string>(i.PropertyName, i.ErrorMessage)).ToList();
    }
}

