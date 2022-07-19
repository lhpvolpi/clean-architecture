using CleanArchitecture.Core.Interfaces.Commands;

namespace CleanArchitecture.Core.Commands.User
{
    public class CreateUserCommand : ICommand
    {
        public CreateUserCommand(string email, string username, string password)
        {
            this.Email = email;
            this.Username = username;
            this.Password = password;
        }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}

