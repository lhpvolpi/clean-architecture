using CleanArchitecture.Core.Interfaces.Commands;

namespace CleanArchitecture.Core.Commands.Authenticate
{
    public class SignInCommand : ICommand
    {
        public SignInCommand(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}

