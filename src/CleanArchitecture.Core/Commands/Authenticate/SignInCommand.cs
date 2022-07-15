using CleanArchitecture.Core.Interfaces.Commands;

namespace CleanArchitecture.Core.Commands.Authenticate
{
    public class SignInCommand : ICommand
    {
        public string? Username { get; set; }

        public string? Password { get; set; }
    }
}

