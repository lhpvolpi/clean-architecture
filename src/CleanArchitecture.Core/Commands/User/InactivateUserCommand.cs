using CleanArchitecture.Core.Interfaces.Commands;

namespace CleanArchitecture.Core.Commands.User
{
    public class InactivateUserCommand : ICommand
    {
        public InactivateUserCommand(string email)
        {
            this.Email = email;
        }

        public string Email { get; set; }
    }
}

