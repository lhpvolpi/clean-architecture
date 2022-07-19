
using CleanArchitecture.Core.Common.Commands;
using CleanArchitecture.Core.Interfaces.Commands;
using FluentValidation.Results;

namespace CleanArchitecture.Core.Common.Extensions
{
    public static class CommandResultExtensions
    {
        public static ICommandResult CreateSuccess200(object data, string message)
            => CommandResult.CreateSuccess(statusCode: 200,
                metadataType: EMetadataType.Object,
                data: data,
                messages: StringExtensions.ToListKeyValuePair(string.Empty, message));

        public static ICommandResult CreateError404(object data, string key, string message)
           => CommandResult.CreateSuccess(statusCode: 404,
               metadataType: EMetadataType.Error,
               data: data,
               messages: StringExtensions.ToListKeyValuePair(key, message));

        public static ICommandResult CreateError422(object data, ValidationResult validationResult)
            => CommandResult.CreateError(statusCode: 422,
                metadataType: EMetadataType.Error,
                data: data,
                messages: validationResult.Errors?.ToListKeyValuePair());
    }
}

