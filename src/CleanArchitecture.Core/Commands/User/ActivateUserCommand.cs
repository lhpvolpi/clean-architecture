using CleanArchitecture.Core.Interfaces.Commands;

namespace CleanArchitecture.Core.Commands.User
{
    public class ActivateUserCommand : ICommand
    {
        public ActivateUserCommand(string email)
        {
            this.Email = email;
        }

        public string Email { get; set; }
    }
}

