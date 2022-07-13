using System.Collections.Generic;
using CleanArchitecture.Core.Interfaces.Commands;

namespace CleanArchitecture.Core.Common.Commands
{
    public class CommandResult : ICommandResult
    {
        public bool Success { get; set; }

        public int StatusCode { get; set; }

        public IMetadata? Metadata { get; set; }

        public dynamic? Results { get; set; }

        public List<KeyValuePair<string, string>>? Messages { get; set; }

        public static CommandResult CreateError(int statusCode,
           EMetadataType metadataType,
           int? start = null,
           int? limit = null,
           int? total = null,
           dynamic? results = null,
           List<KeyValuePair<string, string>>? messages = null)
        {
            return new CommandResult
            {
                Success = false,
                StatusCode = statusCode,
                Metadata = new Metadata(metadataType, start, limit, total),
                Results = results,
                Messages = messages
            };
        }

        public static CommandResult CreateSuccess(int statusCode,
            EMetadataType metadataType,
            int? start = null,
            int? limit = null,
            int? total = null,
            dynamic? results = null,
            List<KeyValuePair<string, string>>? messages = null)
        {
            return new CommandResult
            {
                Success = true,
                StatusCode = statusCode,
                Metadata = new Metadata(metadataType, start, limit, total),
                Results = results,
                Messages = messages
            };
        }

    }

    public class Metadata : IMetadata
    {
        public string Type { get; set; }

        public int? Start { get; set; }

        public int? Limit { get; set; }

        public int? Total { get; set; }

        public Metadata(EMetadataType type, int? start, int? limit, int? total)
        {
            this.Type = nameof(type);
            this.Start = start;
            this.Limit = limit;
            this.Total = total;
        }
    }

    public enum EMetadataType
    {
        Error,

        Object,

        List
    }
}

