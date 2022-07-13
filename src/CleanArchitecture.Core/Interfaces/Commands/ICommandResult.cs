using System.Collections.Generic;

namespace CleanArchitecture.Core.Interfaces.Commands
{
    public interface ICommandResult
    {
        bool Success { get; set; }

        int StatusCode { get; set; }

        IMetadata? Metadata { get; set; }

        dynamic? Results { get; set; }

        List<KeyValuePair<string, string>>? Messages { get; set; }
    }

    public interface IMetadata
    {
        string Type { get; set; }

        int? Start { get; set; }

        int? Limit { get; set; }

        int? Total { get; set; }
    }
}

